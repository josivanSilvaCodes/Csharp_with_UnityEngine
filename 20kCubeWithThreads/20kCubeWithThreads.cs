using UnityEngine;
using System.Threading;

public class CubesWithThreads : MonoBehaviour
{
    float deltaTime;
    float fpsmed = 0;
    int cont = 1;
    float average = 0;

    public GameObject g;
    GameObject[] gs1;
    GameObject[] gs2;
    GameObject[] gs3;
    GameObject[] gs4;
    float velocity = 0;

    private void Start()
    {
        Application.targetFrameRate = 30;

        gs1 = new GameObject[5000];

        for (int i = 0; i < gs1.Length; i++){
            float x = Random.Range(-35.0f, 35.0f);
            float y = Random.Range(-1.0f, 1.0f);
            float z = Random.Range(-35.0f, 35.0f);

            Color c = new Color(
                     Random.Range(0f, 1f),
                     Random.Range(0f, 1f),
                     Random.Range(0f, 1f));

            g.GetComponent<Renderer>().material.color = c;
            gs1[i] = Instantiate(g, g.transform.position, Quaternion.identity);
            gs1[i].transform.position = new Vector3(x, y, z);
            gs1[i].GetComponent<Renderer>().material.color = c;
        }

        gs2 = new GameObject[5000];
        for (int i = 0; i < gs2.Length; i++){
            float x = Random.Range(-35.0f, 35.0f);
            float y = Random.Range(-1.0f, 1.0f);
            float z = Random.Range(-35.0f, 35.0f);

            Color c = new Color(
                     Random.Range(0f, 1f),
                     Random.Range(0f, 1f),
                     Random.Range(0f, 1f));

            g.GetComponent<Renderer>().material.color = c;
            gs2[i] = Instantiate(g, g.transform.position, Quaternion.identity);
            gs2[i].transform.position = new Vector3(x, y, z);
            gs2[i].GetComponent<Renderer>().material.color = c;
        }

        gs3 = new GameObject[5000];
        for (int i = 0; i < gs3.Length; i++){
            float x = Random.Range(-35.0f, 35.0f);
            float y = Random.Range(-1.0f, 1.0f);
            float z = Random.Range(-35.0f, 35.0f);

            Color c = new Color(
                     Random.Range(0f, 1f),
                     Random.Range(0f, 1f),
                     Random.Range(0f, 1f));

            g.GetComponent<Renderer>().material.color = c;
            gs3[i] = Instantiate(g, g.transform.position, Quaternion.identity);
            gs3[i].transform.position = new Vector3(x, y, z);
            gs3[i].GetComponent<Renderer>().material.color = c;
        }

        gs4 = new GameObject[5000];
        for (int i = 0; i < gs4.Length; i++){
            float x = Random.Range(-35.0f, 35.0f);
            float y = Random.Range(-1.0f, 1.0f);
            float z = Random.Range(-35.0f, 35.0f);

            Color c = new Color(
                     Random.Range(0f, 1f),
                     Random.Range(0f, 1f),
                     Random.Range(0f, 1f));

            g.GetComponent<Renderer>().material.color = c;
            gs4[i] = Instantiate(g, g.transform.position, Quaternion.identity);
            gs4[i].transform.position = new Vector3(x, y, z);
            gs4[i].GetComponent<Renderer>().material.color = c;
        }
    }



    void Update(){
        Thread t1 = new Thread(new ThreadStart(DoSomeWorkThreaded1));
        t1.Start();
        Thread t2 = new Thread(new ThreadStart(DoSomeWorkThreaded2));
        t2.Start();
        Thread t3 = new Thread(new ThreadStart(DoSomeWorkThreaded3));
        t3.Start();
        Thread t4 = new Thread(new ThreadStart(DoSomeWorkThreaded4));
        t4.Start();
    }

    void DoSomeWorkThreaded1(){
        for (int i = 0; i < gs1.Length; i++){
            gs1[i].transform.Rotate(0, 10, 0);
            if (Vector3.Distance(gs1[i].transform.position, this.transform.position) < 2){
                velocity = 40;
                gs1[i].GetComponent<Rigidbody>().velocity = new Vector3(0, velocity, 0);
            }
            velocity -= 0.00098f;
            gs1[i].GetComponent<Rigidbody>().velocity = new Vector3(0, velocity, 0);
        }
        this.transform.Rotate(0, 10, 0);
    }

    void DoSomeWorkThreaded2(){
        for (int i = 0; i < gs2.Length; i++){
            gs2[i].transform.Rotate(0, 10, 0);
            if (Vector3.Distance(gs2[i].transform.position, this.transform.position) < 2){
                velocity = 40;
                gs2[i].GetComponent<Rigidbody>().velocity = new Vector3(0, velocity, 0);
            }
            velocity -= 0.00098f;
            gs2[i].GetComponent<Rigidbody>().velocity = new Vector3(0, velocity, 0);
        }
        this.transform.Rotate(0, 10, 0);
    }

    void DoSomeWorkThreaded3(){
        for (int i = 0; i < gs3.Length; i++){
            gs3[i].transform.Rotate(0, 10, 0);
            if (Vector3.Distance(gs3[i].transform.position, this.transform.position) < 2){
                velocity = 40;
                gs3[i].GetComponent<Rigidbody>().velocity = new Vector3(0, velocity, 0);
            }

            velocity -= 0.00098f;
            gs3[i].GetComponent<Rigidbody>().velocity = new Vector3(0, velocity, 0);
        }
        this.transform.Rotate(0, 10, 0);
    }

    void DoSomeWorkThreaded4(){
        for (int i = 0; i < gs4.Length; i++){
            gs4[i].transform.Rotate(0, 10, 0);
            if (Vector3.Distance(gs4[i].transform.position, this.transform.position) < 2){
                velocity = 40;
                gs4[i].GetComponent<Rigidbody>().velocity = new Vector3(0, velocity, 0);
            }

            velocity -= 0.00098f;
            gs4[i].GetComponent<Rigidbody>().velocity = new Vector3(0, velocity, 0);
        }
        this.transform.Rotate(0, 10, 0);
    }

    void OnGUI(){        
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

        if (cont >= 10){
            average = fpsmed / 10;
            fpsmed = 0;
            cont = 1;
        }
        Rect rect2 = new Rect(0, 50, w, h * 2 / 100);
        GUI.Label(rect2, "FPS average: " + Mathf.Ceil(average).ToString(), style);
    }
}

