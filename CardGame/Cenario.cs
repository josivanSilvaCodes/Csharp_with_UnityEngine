using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cenario : MonoBehaviour
{
    [Header("Objetos Jogador x Inimigo")]
    public GameObject player;
    Carta jogador;

    public GameObject enemy;
    Enemy inimigo;

    [Header("Botões do Jogador")]
    public Button buttonAttack1;
    public Button buttonAttack2;
    public Button buttonDefense;
    public Button buttonRunaway;

    [Header("Botões da IA")]
    public Button BtnAtaqueForteIA;
    public Button BtnFugirIA;
    public Button BtnAtaqueComumIA;
    public Button BtnDefesaIA;

    string s = " ";
    bool isPlayerOneTime = true;
    bool IAjogou = false;
    byte timeToChange = 2;


    void Start() // Start is called before the first frame update
    {
        jogador = player.GetComponent<Carta>();
        inimigo = enemy.GetComponent<Enemy>();

        buttonAttack1.onClick.AddListener(Attack1);
        buttonAttack2.onClick.AddListener(Attack2);
        buttonDefense.onClick.AddListener(Defense);
        buttonRunaway.onClick.AddListener(Runaway);
    }


    void Update() // Update is called once per frame
    {
        if (isPlayerOneTime == true)
        {
            buttonAttack1.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            buttonAttack2.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            buttonDefense.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            buttonRunaway.transform.localScale = new Vector3(0.9f, 0.9f, 1);

            BtnAtaqueForteIA.transform.localScale = new Vector3(0, 0, 0);
            BtnFugirIA.transform.localScale = new Vector3(0, 0, 0);
            BtnAtaqueComumIA.transform.localScale = new Vector3(0, 0, 0);
            BtnDefesaIA.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            buttonAttack1.transform.localScale = new Vector3(0, 0, 0);
            buttonAttack2.transform.localScale = new Vector3(0, 0, 0);
            buttonDefense.transform.localScale = new Vector3(0, 0, 0);
            buttonRunaway.transform.localScale = new Vector3(0, 0, 0);

            BtnAtaqueForteIA.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            BtnFugirIA.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            BtnAtaqueComumIA.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            BtnDefesaIA.transform.localScale = new Vector3(0.9f, 0.9f, 1);
        }


        if (isPlayerOneTime == false && IAjogou == false)
        {
            int optionAI = UnityEngine.Random.Range(0, 100);

            if (optionAI <= 25) { inimigo.Attack(jogador); }
            else if (optionAI > 25 && optionAI <= 50) { inimigo.Defense(); }
            else if (optionAI > 50 && optionAI <= 75) inimigo.AttackSpecialMode(jogador);

            IAjogou = true;
            Invoke("changeTime", timeToChange);
        }
    }

    void OnGUI()
    {
        //x    y   lar  alt
        GUI.Label(new Rect(50, 120, 100, 80), s); 
    }
    

    private void changeTime()
    {
        if (isPlayerOneTime == true)
        {
            isPlayerOneTime = false;
            buttonAttack1.enabled = false;
            buttonAttack2.enabled = false;
            buttonDefense.enabled = false;
            buttonRunaway.enabled = false;
            //IAjogou = true;
        }
        else
        {
            isPlayerOneTime = true;
            buttonAttack1.enabled = true;
            buttonAttack2.enabled = true;
            buttonDefense.enabled = true;
            buttonRunaway.enabled = true;
            IAjogou = false;
        }
    }

    public void Attack1()
    {
        jogador.Attack(inimigo);
        Invoke("changeTime", timeToChange);
    }

    public void Attack2()
    {
        jogador.AttackSpecialMode(inimigo);
        Invoke("changeTime", timeToChange);
    }

    public void Defense()
    {
        jogador.Defense();
        Invoke("changeTime", timeToChange);
    }

    public void Runaway()
    {
        jogador.RunAway();
        Invoke("changeTime", timeToChange);
    }


}
