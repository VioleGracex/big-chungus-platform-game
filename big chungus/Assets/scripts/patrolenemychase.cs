using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolenemychase : MonoBehaviour
{
    public GameObject soundwaveleftprefab;
    public GameObject soundwaverightprefab;
    public Transform target;
    public Transform mainbody;
    public Transform[] wp=new Transform[2];
    public Transform laserplace;
    public Transform ground;

    public float speed;
    public float atkcd;
    public float rotationspeed;
    public float atkradiusx = 15f;
    public float atkradiusy = 3f;
    public float pDistance;
    public float hp;

    RaycastHit2D lineofsight;

    private bool movingRight = true;
    bool playerinsight = false;
    bool playerinsightright = false;
    bool playerinrange = false;

    public LayerMask whatisenemy;
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;         
        Gizmos.DrawWireCube(mainbody.transform.position ,new Vector2(atkradiusx, atkradiusy));     
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        Physics2D.queriesStartInColliders = false;
        hp = 3;
    }

    void Update()
    {
        // Debug.Log(playerinsight);
        // Debug.Log(playerinsightright);

       
        if (atkcd>0)
        {
            atkcd -= Time.deltaTime;
        }

        if (transform.position.x<target.position.x)
        {
          playerinsightright = true;

        }
        else
        {
            playerinsightright = false;
        }
        if (playerinsight == true)
        {
            Debug.Log("ri"+playerinsightright);
            if (target.position.x > wp[0].position.x || target.position.x < wp[1].position.x)
            {
               //Debug.Log("nore");
                playerinsight = false;
                return;
            }
            if (playerinsightright == false)
            {
                Debug.Log("re");
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = true;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
            //check if he is in atk position
            Collider2D[] colliders = Physics2D.OverlapBoxAll(mainbody.transform.position, new Vector2(atkradiusx, atkradiusy), whatisenemy);
            {

                for (int i = 0; i < colliders.Length; i++)
                 {
                    //Debug.Log("colliders[i].tag"+ colliders[i].tag);
                     switch (colliders[i].tag)
                         {
                             case "player":
                             //calculate distance
                             playerinrange = true;

                            if(atkcd<=0)
                            {
                                if (playerinsightright == true)
                                {
                                    Instantiate(soundwaverightprefab, mainbody.transform.position + new Vector3(0.8f, 0.3f, 0), Quaternion.identity);
                                   
                                }
                                else
                                {
                                    Instantiate(soundwaveleftprefab, mainbody.transform.position + new Vector3(-0.8f, 0.3f, 0), Quaternion.identity);
                                    
                                }
                                atkcd = 2f;
                            }
                           
                            //                         
                            Debug.Log("atkkkk");
                             break;         

                                 //default:
                         }

                 }
                //Debug.Log("yes no yes" + Mathf.Abs(target.position.x - mainbody.transform.position.x));
                //Debug.Log( Mathf.Abs(target.position.x - mainbody.transform.position.x) > (atkradiusx / 2));
               /* if (colliders[0].tag =="player")
                {         
                    if(atkcd<=0)
                    {
                        // Instantiate(carrotbulletLeftprefab, guninhand.transform.position + new Vector3(-0.8f, 0.3f, 0), Quaternion.identity);
                        Debug.Log("atkkkk");
                        atkcd = 2f;
                    }          
                   
                }   */            
               if (Mathf.Abs(target.position.x - mainbody.transform.position.x) > (atkradiusx / 2) )
                {
                   
                    if(playerinsightright==true)
                    {                        
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        movingRight = true;
                        transform.Translate(Vector2.right * speed * Time.deltaTime);
                    }
                    else
                    {
                        Debug.Log("rew");
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        movingRight = false;
                        transform.Translate(Vector2.left * speed * Time.deltaTime);
                    }

                }
               else
                {
                     if(playerinsightright==true)
                    {                        
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        movingRight = true;
                       // transform.Translate(Vector2.right * speed * Time.deltaTime);
                    }
                    else
                    {
                        Debug.Log("rew");
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        movingRight = false;
                        //transform.Translate(Vector2.left * speed * Time.deltaTime);
                    }
                }
               
            }       
                
           
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        /**/
        RaycastHit2D lineofsightright = Physics2D.Raycast(laserplace.position, Vector2.right, pDistance);
        RaycastHit2D lineofsightleft = Physics2D.Raycast(laserplace.position, Vector2.left, pDistance);

        Debug.DrawLine(laserplace.position, lineofsightright.point, Color.green);
        Debug.DrawLine(laserplace.position, lineofsightleft.point, Color.green);


        RaycastHit2D groundinfo = Physics2D.Raycast(ground.position,Vector2.down,2f);       
        Debug.DrawLine(ground.position, groundinfo.point, Color.red);

        if ( groundinfo.collider.name == "wall"&& playerinsight == true)
        {

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (lineofsightright.collider!=null|| lineofsightleft.collider != null)
        {
            if (playerinsight == false)
            {
                if(lineofsightleft.collider != null)
                {
                    if (lineofsightleft.collider.tag == target.tag && target.position.x < wp[0].position.x && target.position.x > wp[1].position.x && movingRight == false)
                    {                       
                        playerinsightright = false;
                        playerinsight = true;
                    }
                }

                if (lineofsightright.collider != null)
                {
                    if (lineofsightright.collider.tag == target.tag && target.position.x < wp[0].position.x && target.position.x > wp[1].position.x && movingRight == true)
                    {                     
                        playerinsightright = true;
                        playerinsight = true;
                    }
                }
               
               
                    if (groundinfo.collider == false || groundinfo.collider.tag == "boxes" || groundinfo.collider.name == "wall")
                    {
                        if (movingRight == true)
                        {
                            transform.eulerAngles = new Vector3(0, -180, 0);
                            movingRight = false;
                        }
                        else
                        {
                            transform.eulerAngles = new Vector3(0, 0, 0);
                            movingRight = true;
                        }
                    }
                
            }

        }
        

     
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    public void damagedone()
    {
        if (hp <= 0)
        {
            //animator.SetBool("isdead", true);
        }
    }
}