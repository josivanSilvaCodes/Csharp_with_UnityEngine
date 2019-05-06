
using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

public class CubesWithJobSystem : MonoBehaviour
{
    float deltaTime;
    float fpsmed = 0;
    int cont = 1;
    float average = 0;

    public GameObject g;
    [SerializeField] Transform[] targets;    
    GameObject [] gs;

    NativeArray<float> velocity;
    NativeArray<RaycastCommand> commands;
    NativeArray<RaycastHit> results;
    TransformAccessArray transformArray;

    IsHitGroundJob hitCheckJob;

    JobHandle handle, hitcheckHandle;

    private void Awake()
    {
        targets = new Transform[20000];
        gs = new GameObject[20000];

        for (int i = 0; i < targets.Length; i++)
        {
            float x = Random.Range(-35.0f, 35.0f);
            float y = Random.Range(-1.0f, 1.0f);
            float z = Random.Range(-35.0f, 35.0f);

            Color c = new Color(
                     Random.Range(0f, 1f),
                     Random.Range(0f, 1f),
                     Random.Range(0f, 1f)
                     );

            g.GetComponent<Renderer>().material.color = c;

            gs[i] = Instantiate(g, targets[i]);
            targets[i] = gs[i].transform;
            gs[i].transform.position = new Vector3(x, y, z);

            gs[i].GetComponent<Renderer>().material.color = c;




        }
    }

    void OnEnable()
    {
        velocity = new NativeArray<float>(targets.Length, Allocator.Persistent);
        commands = new NativeArray<RaycastCommand>(targets.Length, Allocator.Persistent);
        results = new NativeArray<RaycastHit>(targets.Length, Allocator.Persistent);
        for (int i = 0; i < targets.Length; i++)
        {
            velocity[i] = -1;
        }
        transformArray = new TransformAccessArray(targets);

        hitCheckJob = new IsHitGroundJob()
        {
            raycastResults = results,
            result = new NativeArray<int>(1, Allocator.Persistent)
        };

    }

    void OnDisable()
    {
        handle.Complete();
        hitcheckHandle.Complete();
        velocity.Dispose();
        commands.Dispose();
        results.Dispose();
        hitCheckJob.result.Dispose();
        transformArray.Dispose();
    }

    void Update()
    {
        handle.Complete();
        hitcheckHandle.Complete();

        this.transform.Rotate(0, 10f, 0);

        for (int i = 0; i < transformArray.length; i++)
        {
            var targetPosition = transformArray[i].position;
            var direction = Vector3.down;
            var command = new RaycastCommand(targetPosition, direction);
            commands[i] = command;
            gs[i].transform.Rotate(0, 10f, 0);
        }

        var updatePositionJob = new UpdatePosition()
        {
            raycastResults = results,
            velocitys = velocity
        };

        var applyPosition = new ApplyPosition()
        {
            velocitys = velocity
        };

        var raycastJobHandle = RaycastCommand.ScheduleBatch(commands, results, 20);
        hitcheckHandle = hitCheckJob.Schedule(raycastJobHandle);
        var updatePositionHandle = updatePositionJob.Schedule(transformArray.length, 20, raycastJobHandle);
        handle = applyPosition.Schedule(transformArray, updatePositionHandle);

        JobHandle.ScheduleBatchedJobs();
    }

    struct UpdatePosition : IJobParallelFor
    {
        [ReadOnly] public NativeArray<RaycastHit> raycastResults;
        public NativeArray<float> velocitys;

        void IJobParallelFor.Execute(int index)
        {
            if (velocitys[index] < 0 &&
                raycastResults[index].distance < 0.5f)
            {
                velocitys[index] = 2.0f;
            }
            velocitys[index] -= 0.098f;
        }
    }

    struct ApplyPosition : IJobParallelForTransform
    {
        public NativeArray<float> velocitys;

        void IJobParallelForTransform.Execute(int index, TransformAccess transform)
        {
            transform.localPosition += Vector3.up * velocitys[index];
        }
    }

    struct IsHitGroundJob : IJob
    {
        [ReadOnly] public NativeArray<RaycastHit> raycastResults;
        [WriteOnly] public NativeArray<int> result;

        void IJob.Execute()
        {
            for (int i = 0; i < raycastResults.Length; i++)
            {
                if (raycastResults[i].distance < 1f)
                {
                    result[0] = 0;
                    return;
                }
            }
            result[0] = 1;
        }
    }

    void OnGUI()
    {
        

        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        string text = "FPS: " + Mathf.Ceil(fps).ToString();

        fpsmed += Mathf.Ceil(fps);
        cont++;

        int w = Screen.width;
        int h = Screen.height;

        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 10 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
       
        GUI.Label(rect, text, style);


        if (cont >= 10)
        {
            average = fpsmed / 10;
            fpsmed = 0;
            cont = 1;
        }

        Rect rect2 = new Rect(0, 50, w, h * 2 / 100);
        GUI.Label(rect2, "FPS average: " + Mathf.Ceil(average).ToString(), style);
    }
}
