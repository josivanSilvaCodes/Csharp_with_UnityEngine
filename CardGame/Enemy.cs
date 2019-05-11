using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int attackPower;
    public int defensePower;
    public int lifeBar;
    public int hit;
    public string cardType;

    public int posx;
    public int posy;
    public int w;
    public int h;

    public string status;

    void Awake() // Start is called before the first frame update
    {
        attackPower = UnityEngine.Random.Range(20, 100);
        defensePower = UnityEngine.Random.Range(20, 100);
        lifeBar = 100;
        hit = (int)(((attackPower + defensePower) / 2) * (0.2));

        if (attackPower >= defensePower)
        { cardType = "Attack Card"; }
        else { cardType = "Defense Card"; }

        posx = 630;
        posy = 30;
        w = 160;
        h = 120;
        status = "";
    }

    void Update() // Update is called once per frame
    {

    }

    public void Attack(Carta c)
    {
        posx -= 10;
        status = "Attacking";
        c.lifeBar -= (hit);
    }

    public void AttackSpecialMode(Carta c)
    {
        posx -= 20;
        status = "Attacking";
        c.lifeBar -= (hit*3);
    }

    public void Defense()
    {
        posx += 10;
        status = "Defending";
    }

    public void RunAway()
    {
        status = "running away";
    }

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 22;
        myStyle.normal.textColor = Color.red;

        string textInfo = "  " + cardType + "\n"
                          + "  Attack: " + attackPower + "\n"
                          + "  Defense: " + defensePower + "\n"
                          + "  Life: " + lifeBar + "% \n";

        GUI.Box(new Rect(posx, posy, w, h), "");
        GUI.Box(new Rect(posx, posy, w, h), textInfo, myStyle);
        //GUI.Label(new Rect(posx, (posy + 100), 100, 50), status);

    }
}     //Fim class
