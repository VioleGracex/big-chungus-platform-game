using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalplatform : MonoBehaviour {

    private PlatformEffector2D effector;
    public float waittime =0.5f;
    int pressed=0;
    bool press = false;
    // Use this for initialization
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waittime > 0 && press==true)
        {
            waittime -= Time.deltaTime;
        }
        if(waittime<=0)
        {
            press = false;
            pressed = 0;
            waittime = 0.5f;
        }
        if (pressed >= 2&&waittime>0&&press==true)
        {
            effector.rotationalOffset = 180f;
            press = false;
            pressed = 0;
            waittime = 0.5f;
        }

        if (Input.GetKeyUp("s"))
        {
            waittime =0.5f;
        }
        if (Input.GetKeyDown("s"))
        {
            pressed++;
            press = true; 
          
        }
        if (Input.GetKey("w")|| Input.GetKey("space"))
        {
            effector.rotationalOffset = 0;
        }
    }
}
