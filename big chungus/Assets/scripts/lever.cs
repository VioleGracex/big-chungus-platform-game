using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour {

    public GameObject mydoor;
    public GameObject pullposition;
    public Animator gateanimator;
    public float doorspeed;
    public bool ispulled=false;
    SpriteRenderer spriterender;
    public Collider2D gatecollider;
    Vector3 doorposition;
    Vector3 doorpulledposition;
    Vector3 theScale;

    // Use this for initialization
    void Start ()
    {
        this.spriterender = GetComponent<SpriteRenderer>();
        doorposition = mydoor.transform.position;
        doorpulledposition = pullposition.transform.position;
        //doorpulledposition = doorpositon+new Vector3(0,3,0);
        theScale = transform.localScale;
       
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(ispulled==true)
        {
            //open gate  disable its collider and move the y axis up 
            //gateanimator.SetBool("ispulled", true);
            if (theScale.x>0)
            {
                flip();
            }
           

            gatecollider.enabled = false;
            if(doorpulledposition.y>mydoor.transform.position.y)
            {
                mydoor.transform.Translate( Vector2.up  * doorspeed * Time.deltaTime);
            }
           
        }
        else
        {
            //close gate move collider y axis down then enable collider
            gateanimator.SetBool("ispulled", false);
            if (theScale.x < 0)
            {
                flip();
            }

            if (doorposition.y < mydoor.transform.position.y)
            {
                mydoor.transform.Translate(Vector2.down * doorspeed * Time.deltaTime);
            }
            else
            {
                gatecollider.enabled = true;
            }
            
        }

	}
    void flip()
    {
        theScale.x *= -1;
        transform.localScale = theScale;
    }
   
}
