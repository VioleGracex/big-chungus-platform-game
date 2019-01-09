using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryswitcher : MonoBehaviour {

    public GameObject iteminhand;
    public GameObject iteminbelt;
    public Animator animator;
    public string itemname;   
    string inhand;

  
    // Use this for initialization
    void Start ()
    {
        animator = FindObjectOfType<playermovement>().animator;
    }
	
	// Update is called once per frame
	void Update ()
    {
        inhand = FindObjectOfType<playermovement>().inhand;
        if (inhand == itemname)
        {
            iteminhand.SetActive(true);
            iteminbelt.SetActive(false);
        }
        else
        {
            iteminbelt.SetActive(true);
            iteminhand.SetActive(false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("jump") || animator.GetCurrentAnimatorStateInfo(0).IsName("fall")|| animator.GetCurrentAnimatorStateInfo(0).IsName("walking")|| animator.GetCurrentAnimatorStateInfo(0).IsName("pushingwalking")|| animator.GetCurrentAnimatorStateInfo(0).IsName("pushidle"))
        {
            iteminhand.SetActive(false);
            iteminbelt.SetActive(true);
        }
        
    }
}
