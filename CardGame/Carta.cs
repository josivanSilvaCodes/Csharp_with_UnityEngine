using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
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
        attackPower = Random.Range(20, 100);
        defensePower = Random.Range(20, 100);
        lifeBar = 100;
        hit = (int)(((attackPower + defensePower) / 2) * (0.2));
        
        if (attackPower >= defensePower)
        { cardType = "Attack Card"; }
        else{ cardType = "Defense Card"; }

        posx = 30;
        posy = 30;
        w = 160;
        h = 120;
        status = "";
    }
    
    void Update() // Update is called once per frame
    {
        
    }

    public void Attack(Enemy e)
    {
        posx += 10;
        status = "Attacking";
        e.lifeBar -= hit;
    }

    public void AttackSpecialMode(Enemy e)
    {
        posx += 20;
        status = "Special Attacking ";
        e.lifeBar -= (hit*3);
    }

    public void Defense()
    {
        posx -= 10;
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
        myStyle.normal.textColor = Color.yellow;

        string textInfo = "  " + cardType + "\n"
                          + "  Attack: " + attackPower + "\n"
                          + "  Defense: " + defensePower + "\n"
                          + "  Life: " + lifeBar + "% \n";

        GUI.Box(new Rect(posx, posy, w, h), "");
        GUI.Box(new Rect(posx, posy, w, h), textInfo, myStyle);
        //GUI.Label(new Rect(posx, (posy + 100), 100, 50), status);
       
    }
}     //Fim class
