using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carrothp : MonoBehaviour {

   Image myImageComponent;
   public Sprite carrotfull;
   public Sprite carrothalf;
   public Sprite carrotlast;
   public Sprite carrotempty;
   int hp = 3;

    // Use this for initialization
    void Start ()
    {
        myImageComponent = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        hp = FindObjectOfType<playermovement>().hp;
        if (hp == 3)
        {
            myImageComponent.sprite = carrotfull;
        }
        else if (hp==2)
        {
            myImageComponent.sprite = carrothalf;
        }
        else if(hp==1)
        {
            myImageComponent.sprite = carrotlast;
        }
        else
        {
            myImageComponent.sprite = carrotempty;
        }
    }
}
