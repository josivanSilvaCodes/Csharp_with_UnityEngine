
using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

public class 20kCubesWhithSimpleMethod : MonoBehaviour
{
    float deltaTime;
    float fpsmed = 0;
    int cont = 1;
    float average = 0;

    public GameObject g;
    GameObject[] gs;
    float velocity = 0;
    


    private void Start()
    {
        Application.targetFrameRate = 30;

        gs = new GameObject[2000];

        for (int i = 0; i < gs.Length; i++)
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

            gs[i] = Instantiate(g, g.transform.position, Quaternion.identity);
            gs[i].transform.position = new Vector3(x, y, z);
            gs[i].GetComponent<Renderer>().material.color = c;

        }
    }


  
    void Update()
    {
        for (int i = 0; i < gs.Length; i++)
        {
            gs[i].transform.Rotate(0, 10, 0);
            if (Vector3.Distance(gs[i].transform.position, this.transform.position) < 2)
            {
                velocity = 40;
                gs[i].GetComponent<Rigidbody>().velocity = new Vector3(0, velocity, 0);
            }

            velocity -= 0.00098f;
            gs[i].GetComponent<Rigidbody>().velocity = new Vector3(0, velocity, 0);
        }
        this.transform.Rotate(0, 10, 0);

        
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
