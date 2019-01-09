using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotGun : MonoBehaviour
{
    public GameObject carrotguninhand;
    public GameObject carrotguninbelt;
    public Animator animator;
    string inhand;

    // Use this for initialization
    void Start ()
    {
        animator = FindObjectOfType<playermovement>().animator;
    }

    // Update is called once per frame
    void Update()
    {
        inhand = FindObjectOfType<playermovement>().inhand;
        if (inhand == "gun")
        {
            carrotguninhand.SetActive(true);
            carrotguninbelt.SetActive(false);
        }
        else
        {
            carrotguninbelt.SetActive(true);
            carrotguninhand.SetActive(false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Crawl") || animator.GetCurrentAnimatorStateInfo(0).IsName("idlecrouch"))
        {
            carrotguninhand.SetActive(false);
            carrotguninbelt.SetActive(false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("jump") || animator.GetCurrentAnimatorStateInfo(0).IsName("fall") || animator.GetCurrentAnimatorStateInfo(0).IsName("walking")|| animator.GetCurrentAnimatorStateInfo(0).IsName("walking") || animator.GetCurrentAnimatorStateInfo(0).IsName("pushingwalking") || animator.GetCurrentAnimatorStateInfo(0).IsName("pushidle"))
        {
            carrotguninhand.SetActive(false);
            carrotguninbelt.SetActive(true);
        }
        if (carrotguninhand.activeSelf)
        {
            animator.SetBool("gunout", true);
        }
        else
        {
            animator.SetBool("gunout", false);
        }
    }
   
}
