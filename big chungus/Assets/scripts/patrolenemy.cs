using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolenemy : MonoBehaviour
{
    Rigidbody2D myrigidbody;
    public Animator anim;
    public GameObject[] waypoint = new GameObject[3];
    Vector3[] destnation = new Vector3[3];
    Vector3[] pos = new Vector3[3];
    Vector3Int[] centerpos = new Vector3Int[3];
    Vector3Int[] wp = new Vector3Int[3];
    Vector3Int cellcenterpos;
    char keydown = 'i';
    bool isidle = true;
    bool stop=true;
    GameObject target = null;
    public float panSpeed = 1.5f;
    string enemyname;
    string[] effectorname = new string[12];
    public Vector3 attackpos;
    public LayerMask whatisenemy;
    public LayerMask whatiseffect;
    public float attack_range = 1.5f;
    public float movement_delay = 0f;
    public float damaged_state_persec = 0f;
    public int hp = 3;
    int wp_in_progress = 0;
    float damagecd = 0;
    [SerializeField] private Collider2D mycollider1;
    [SerializeField] private Collider2D mycollider2;
    [SerializeField] private Collider2D mycollider3;

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log(" coll name " + collider.gameObject.name);
        switch (collider.gameObject.tag)
        {
            case "bullet":
                takedamagebullet(collider.transform.position);
                //anim.SetBool("isdamaged", false);
                break;
                /* case "player":
                     stop = true;
                     anim.SetBool("iswalking", false);
                   //anim.SetBool("isdamaged", false);
                     break;*/
                //default:
        }
    }
    // Use this for initialization

    void Start ()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        Vector3 charpos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Vector3Int cellcenterpos = FindObjectOfType<wave_class>().get_cent(charpos);

        destnation[0] = new Vector3(waypoint[0].transform.position.x, waypoint[0].transform.position.y, waypoint[0].transform.position.z);
        wp[0] = FindObjectOfType<wave_class>().get_cent(destnation[0]);

        destnation[1] = new Vector3(waypoint[1].transform.position.x, waypoint[1].transform.position.y, waypoint[1].transform.position.z);
        wp[1] = FindObjectOfType<wave_class>().get_cent(destnation[1]);
        CheckForFlip();
    }

    // Update is called once per frame
    void Update ()
    {
        
        Vector3 charpos = transform.position;
        cellcenterpos = FindObjectOfType<wave_class>().get_cent(charpos);
        Vector2 movement_vector = new Vector2(0, 0);

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            mycollider2.enabled = false;
        }
        else
        {
            mycollider2.enabled = true;
        }


            if (cellcenterpos.x == wp[wp_in_progress].x )
        {
            stop = true;           
            anim.SetBool("iswalking", false);
            CheckForFlip();
            keydown = 'i';
           if(wp_in_progress==0)
            {
                wp_in_progress = 1;
            }
           else
            {
                wp_in_progress = 0;
            }
        }

        if(stop==false)
        {
            anim.SetBool("iswalking", true);
            if (cellcenterpos.x != wp[wp_in_progress].x)
            {
                if (cellcenterpos.x < wp[wp_in_progress].x)
                {
                    keydown = 'd';
                }
                else if (cellcenterpos.x > wp[wp_in_progress].x)
                {
                    keydown = 'a';
                }

            }
        }
        else
        {

        }
      

        if(myrigidbody.velocity.x>0&&isidle==false)
        {
            anim.SetBool("iswalking", true);
        }
        else
        {
            //anim.SetBool("iswalking", true);
        }

        if (keydown == 'd')
        {          
          
            isidle = false;
            charpos.x += panSpeed * Time.deltaTime;
            movement_vector.x = panSpeed * Time.deltaTime;           
        }
        else if (keydown == 'a')
        {                     
            isidle = false;
            charpos.x -= panSpeed * Time.deltaTime;
            movement_vector.x = panSpeed * Time.deltaTime;          
        }
        else
        {
            isidle = true;           
        }
       
        transform.position = charpos;

        if(damagecd>0)
        {
            damagecd -= Time.deltaTime;
        }
    }

    public void startmoving()
    {
        anim.SetBool("iswalking", true);
        stop =false;
    }
    public void damagedone()
    {
        anim.SetBool("isdamaged", false);
        anim.SetBool("isdamagedbullet", false);
        anim.SetBool("iswalking", true);
        stop = false;
        if (hp <= 0)
        {
            myrigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;//| RigidbodyConstraints2D.FreezePositionY;
            panSpeed = 0;
            //mycollider1.enabled = false;
            mycollider2.enabled = false;
            mycollider3.enabled = true;

            anim.SetBool("isdead", true);
        }
       
    }
    public void takedamage(Vector3 hitposition)
    {
        if (damagecd <= 0)
        {
            hp--;
            damagecd = 0.2f;
            if (hitposition.x > transform.position.x)
            {
                myrigidbody.AddForce(new Vector2(-500f, 250f));
            }
            else
            {
                myrigidbody.AddForce(new Vector2(500f, 250f));
            }
            anim.SetBool("isdamaged", true);
            stop = true;
        }
       
    }
    public void takedamagebullet(Vector3 hitposition)
    {
        if (damagecd <= 0)
        {
            hp--;
            damagecd = 0.2f;
            if (hitposition.x > transform.position.x)
            {
                myrigidbody.AddForce(new Vector2(-250f, 125f));
            }
            else
            {
                myrigidbody.AddForce(new Vector2(250f, 125f));
            }
            anim.SetBool("isdamagedbullet", true);
            
        }

    }
    private void CheckForFlip()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        if (destnation[wp_in_progress].x>transform.position.x)
        {
            theScale.x *= -1;
        }
        else if(destnation[wp_in_progress].x < transform.position.x)
        {
            theScale.x *= -1;
        }
       
        transform.localScale = theScale;
    }
    public void dead()
    {
        Destroy(gameObject);
    }

}
