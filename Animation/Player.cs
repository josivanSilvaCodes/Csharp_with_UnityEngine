using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetBool("tocar2", true);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetBool("tocar2", false);
        }
    }
}
