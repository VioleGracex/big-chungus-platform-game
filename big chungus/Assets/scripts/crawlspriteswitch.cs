using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crawlspriteswitch : MonoBehaviour
{
    public GameObject player;
    public GameObject adjuster;
    public SpriteRenderer spriterender;
    public Sprite noncrawlingsprite;
    public Sprite crawlingsprite;
    public Animator animator;
    public Animator itemanimator;
    public int crawlsortlayer;
    public int noncrawlsortlayer;
    public bool crawlanimation=false;
    public bool adjust = false;
    Vector3 orgplace;
    bool crawling;
    // Use this for initialization
    void Start()
    {
        //transform.position=player.transform.position.x-
        this.spriterender = GetComponent<SpriteRenderer>();
        animator = FindObjectOfType<playermovement>().animator;
        orgplace = transform.position;
        // itemanimator = this.animator;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Crawl") || animator.GetCurrentAnimatorStateInfo(0).IsName("idlecrouch"))
        {
          
            if (crawlanimation == true)
            {              
                itemanimator.SetBool("itemcrawling", true);        
                spriterender.sortingOrder = crawlsortlayer;
            }
            else
            {               
                spriterender.sprite = crawlingsprite;
                spriterender.sortingOrder = crawlsortlayer;
            }
            if (adjust == true)
            {
                gameObject.transform.position = adjuster.gameObject.transform.position;
            }


        }
        else
        {
            if (adjust == true)
            {
                gameObject.transform.position = orgplace;
            }
            if (crawlanimation == true)
            {            
                itemanimator.SetBool("itemcrawling", false);
                spriterender.sortingOrder = noncrawlsortlayer;
            }
            else
            {               
                spriterender.sprite = noncrawlingsprite;
                spriterender.sortingOrder = noncrawlsortlayer;
            }          
            

            //animator.SetBool("itemcrawling", crawlanimation);
        }

    }
}
