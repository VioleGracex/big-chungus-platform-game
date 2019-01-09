using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour {

    public CharacterController2D controller;

    public int hp = 3;
    int interactkeypressed=1;

    public GameObject gun;
    public GameObject guninhand;
    public GameObject hammer;
    public GameObject belt;
    public GameObject InteractTarget;
    public GameObject carrotbulletprefab;
    public GameObject carrotbulletLeftprefab;

    public Animator animator;


    public float horizontalmove = 0f;
    public float runspeed = 40;
    public float reloadspeed = 0f;
    public float hammercd = 0f;
    public float swinghammercd = 0f;

    bool jump = false;
    bool crouch = false;
    bool isfalling = false;
    bool isatking = false;
    bool stunned = false;

    const float atkradius = .5f;
    const float interactradius = 1.5f;

    Vector3 atkpos;

    public LayerMask whatisenemy;
    public LayerMask whatisinteractables;

    float damagedcd = 0f;
    bool damage = false;
    public string inhand = "empty";
    bool pushing = false;
 

    // Use this for initialization


    void OnTriggerEnter2D(Collider2D collider)
    {
        
        switch (collider.gameObject.tag)
        {
            case "item":
                if (collider.gameObject.name == "Hammer")
                {
                    hammer.SetActive(true);
                    belt.SetActive(true);
                }
                else if (collider.gameObject.name == "gun")
                {
                    gun.SetActive(true);
                }
                break;
            case "enemy":
                if (damagedcd<=0)
                {
                    hp--;
                    belt.SetActive(false);                   
                    animator.SetBool("isfalling", false);
                    animator.SetBool("iswalking", false);
                    animator.SetBool("isdamaged", true);
                    damage = true;
                    damagedcd = 1.5f;
                    //stunned = true;
                    
                    if (collider.transform.position.x > transform.position.x)
                    {
                        FindObjectOfType<CharacterController2D>().m_Rigidbody2D.AddForce(new Vector2(-1500f, 500f));
                    }
                    else
                    {
                        FindObjectOfType<CharacterController2D>().m_Rigidbody2D.AddForce(new Vector2(1500f, 500f));
                    }
                }
               
                //damaged
                break;
            case "enemybullet":
                if (damagedcd <= 0)
                {
                    hp--;
                    belt.SetActive(false);
                    animator.SetBool("isfalling", false);
                    animator.SetBool("iswalking", false);
                    animator.SetBool("isdamaged", true);
                    damage = true;
                    damagedcd = 1.5f;
                    //stunned = true;

                    if (collider.transform.position.x > transform.position.x)
                    {
                        FindObjectOfType<CharacterController2D>().m_Rigidbody2D.AddForce(new Vector2(-1500f, 500f));
                    }
                    else
                    {
                        FindObjectOfType<CharacterController2D>().m_Rigidbody2D.AddForce(new Vector2(1500f, 500f));
                    }
                }

                //damaged
                break;
                //default:
        }
    }
    // Update is called once per frame
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Vector3 theScale = transform.localScale;
        if (theScale.x < 0)
        {
            Gizmos.DrawWireSphere(transform.position + new Vector3(-1f, -0.2f, 0), atkradius);

        }
        else
        {
            Gizmos.DrawWireSphere(transform.position + new Vector3(1f, -0.2f, 0), atkradius);
        }
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position , interactradius);
    }

   void Update ()
    {
         //------------------------------ pushing functions ----------------------------
        if (pushing == true)
        {
            animator.SetBool("ispushing", true);
            bool pushingfromright=false;
            if (transform.position.x > InteractTarget.transform.position.x)
            {
                pushingfromright = true;              
                horizontalmove = -1;
                transform.position = InteractTarget.transform.position + new Vector3(1.5f, 0.37f, 0);
            }
            else if (transform.position.x <= InteractTarget.transform.position.x)
            {               
                transform.position = InteractTarget.transform.position + new Vector3(-1.5f, 0.37f, 0);
                horizontalmove = 1;
            }
            if (Input.GetKeyDown("f"))//for disabling interacting
            {
                pushing = false;
                animator.SetBool("ispushing", false);
                interactkeypressed = 1;
                if(pushingfromright == true)
                {
                    transform.position = InteractTarget.transform.position + new Vector3(1.5f, 0.5f, 0);
                    horizontalmove = -1;                  
                }
                else
                {
                    transform.position = InteractTarget.transform.position + new Vector3(-1.5f, 0.5f, 0);
                    horizontalmove = 1;                
                }
               
                
            }

            Rigidbody2D boxrigidbody = InteractTarget.GetComponent<Rigidbody2D>();

            if (Input.GetKey("d"))
            {              
                boxrigidbody.AddForce(new Vector2(125f, 0));
                animator.SetInteger("animation", 1);                     
            }
            else if(Input.GetKey("a"))
            {
                boxrigidbody.AddForce(new Vector2(-125f, 0));             
                animator.SetInteger("animation", 1);
            }
            else
            {
                animator.SetInteger("animation", 0);
            }
            return;
        }

        //------------------------------- normal functions ------------------------------------
        if (stunned==false&&pushing==false)
        {
            if (isatking == false)
            {
                horizontalmove = Input.GetAxisRaw("Horizontal") * runspeed;

                animator.SetFloat("Speed", Mathf.Abs(horizontalmove));
                if (reloadspeed > 0)
                {
                    reloadspeed -= Time.deltaTime;
                }

                //inventory buttons 

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {                                                          
                        inhand = "empty";                   
                }
                
                else if (Input.GetKeyDown(KeyCode.Alpha2)&& gun.activeSelf)
                {

                    if (inhand=="empty")
                    {
                        inhand = "gun";
                    }
                    else
                    {
                        inhand = "empty";
                    }
                   
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3) && hammer.activeSelf)
                {

                    if (inhand == "empty")
                    {
                        inhand = "Hammer";
                    }
                    else
                    {
                        inhand = "empty";
                    }

                }

                //-------------------------- input keys --------------------------
                if (Input.GetKeyDown("e") && gun.activeSelf && reloadspeed <= 0 && inhand =="gun")
                {
                    reloadspeed = 3f;
                    Vector3 theScale = transform.localScale;
                    if (theScale.x < 0)
                    {
                        Instantiate(carrotbulletLeftprefab, guninhand.transform.position + new Vector3(-0.8f, 0.3f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(carrotbulletprefab, guninhand.transform.position + new Vector3(0.8f, 0.3f, 0), Quaternion.identity);
                    }
                }


                if (Input.GetKeyDown(KeyCode.Mouse0) && hammer.activeSelf && hammercd <= 0 && jump == false && crouch == false && FindObjectOfType<CharacterController2D>().m_Grounded && FindObjectOfType<CharacterController2D>().m_Rigidbody2D.velocity.x < 0.5&& isfalling==false && inhand=="Hammer")
                {
                    hammercd = 1.5f;
                    horizontalmove = 0;
                    FindObjectOfType<CharacterController2D>().m_JumpForce = 0;
                    Debug.Log("HAMMERTIME");
                    isatking = true;
                    animator.SetBool("isatking", isatking);
                }
                if (Input.GetKeyDown(KeyCode.Mouse1) && hammer.activeSelf && swinghammercd <= 0 && jump == false && crouch == false && FindObjectOfType<CharacterController2D>().m_Grounded && FindObjectOfType<CharacterController2D>().m_Rigidbody2D.velocity.x < 0.5 && isfalling == false && inhand == "Hammer")
                {
                    swinghammercd = 3f;
                    horizontalmove = 0;
                    FindObjectOfType<CharacterController2D>().m_JumpForce = 0;
                    Debug.Log("swingHAMMERTIME");
                    //isatking = true;
                    //animator.SetBool("isatking", isatking);
                }

                if (Input.GetButtonDown("Jump"))
                {
                    jump = true;
                    animator.SetBool("isjumping", true);
                }

                if (Input.GetButtonDown("Crouch"))
                {
                    crouch = true;
                    //animator.SetBool("iscrouching", crouch);
                }
                else if (Input.GetButtonUp("Crouch"))
                {
                    crouch = false;
                    //animator.SetBool("iscrouching", crouch);
                }

                if (Input.GetKeyDown("f"))//for interacting
                {               
                    //scanning for Interactable objects    
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactradius, whatisinteractables);
                    float distance=-100;

                    for (int i = 0; i < colliders.Length; i++)
                    {
                        if (colliders[i].gameObject != gameObject)
                        {
                            switch (colliders[i].tag)
                            {
                                case "boxes":
                                    //calculate distance
                                   
                                    float tempdistance = colliders[i].gameObject.transform.position.x - transform.position.x;
                                 
                                    if (tempdistance>distance)
                                    {
                                      
                                        distance = tempdistance;
                                        InteractTarget = colliders[i].gameObject;
                                    }
                                    pushing = true;
                                    break;
                                case "levers":
                                    //calculate distance

                                    colliders[i].GetComponent<lever>().ispulled = !colliders[i].GetComponent<lever>().ispulled;



                                    break;

                                    //default:
                            }
                        }
                    }
                   
                }
                
                

            }

            
            //---------------------------- atking functions -------------------------------
            if (isatking == true)
            {
                horizontalmove = 0;
                jump = false;
                crouch = false;
                belt.SetActive(false);

                Vector3 theScale = transform.localScale;
                if (theScale.x < 0)
                {
                    atkpos = transform.position + new Vector3(-1f, -0.2f, 0);
                }
                else
                {
                    atkpos = transform.position + new Vector3(1f, -0.2f, 0);
                }

                //scanning for colliders with overlap
                Collider2D[] colliders = Physics2D.OverlapCircleAll(atkpos, atkradius, whatisenemy);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        switch (colliders[i].tag)
                        {
                            case "enemy":
                                //reduce enemies hp
                                colliders[i].GetComponent<patrolenemy>().takedamage(transform.position);
                                break;

                                //default:
                        }
                    }
                }
            }

        }
        else
        {
            horizontalmove = 0;
            animator.SetBool("iswalking", false);
            animator.SetBool("iscrouching", false);
        }

        //--------------------- checking if falling through y velocity ------------------------
        if (jump == false && FindObjectOfType<CharacterController2D>().m_Rigidbody2D.velocity.y < -1)
        {
            isfalling = true;
            animator.SetBool("isfalling", isfalling);
        }
        else
        {
            isfalling = false;
            animator.SetBool("isfalling", isfalling);
        }

        if (hammercd > 0)
        {
            hammercd -= Time.deltaTime;
        }

        if(damagedcd>0&&damage==true)
        {
            damagedcd -= Time.deltaTime;
        }
       
    }

    // function called when hp <0
    public void Dead()
    {
        //summonrespawn menu
        Destroy(gameObject);
    }

    // using event system i can check if am touching a colldier on ground 
    public void OnLanding()
    {
        animator.SetBool("isjumping", false);
    }

    // using event system i can check if i am crouching
    public void OnCrouching(bool IsCrouching)
    {
        //Debug.Log("is" + IsCrouching);
        animator.SetBool("iscrouching", IsCrouching);
    }

    public void atkended()
    {
        isatking = false;
        belt.SetActive(true);
        //hammer.SetActive(true);
        FindObjectOfType<CharacterController2D>().m_JumpForce = 700;
        animator.SetBool("isatking", isatking);
    }
    void FixedUpdate()
    {
        //Debug.Log(crouch);
        controller.Move(horizontalmove*Time.fixedDeltaTime,crouch,jump);
        jump = false;
        

    }

    // function called by animation controller when hp < 0
    public void damagedone()
    {
        animator.SetBool("isfalling", false);
        animator.SetBool("iswalking", false);
        animator.SetBool("isdamaged", false);
        belt.SetActive(true);
        stunned = false;
        if (hp <= 0)
        {
            FindObjectOfType<CharacterController2D>().m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;//| RigidbodyConstraints2D.FreezePositionY;
                                                                                                                        
            animator.SetBool("isdead", true);
        }

    }
}
