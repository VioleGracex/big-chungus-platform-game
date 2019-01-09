using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class audiosavedata : MonoBehaviour {

    // Use this for initialization
    float value;
    float menuvalue;
    public Slider masterslider;
    public Slider menuslider;
    public float firstvalue;
    public float secvalue;
    void Awake()
    {
        //Debug.Log("t");        
        //Debug.Log("t" + masterslider.value);
       masterslider.value = FindObjectOfType<loadoutlistdonotdestroy>().firstvalue;
       menuslider.value = FindObjectOfType<loadoutlistdonotdestroy>().secvalue;

    }
    void Start ()
    {
		
	}
    public void saveoptions()
    {
        FindObjectOfType<loadoutlistdonotdestroy>().firstvalue=firstvalue ;
        FindObjectOfType<loadoutlistdonotdestroy>().secvalue = secvalue;
    }

    // Update is called once per frame
    void Update ()
    {
        FindObjectOfType<OptionsMenu>().SetVolume(value);
        firstvalue = masterslider.value;
        secvalue = menuslider.value;
        if (value != masterslider.value)
        {
            FindObjectOfType<OptionsMenu>().SetVolume(masterslider.value);
            // Debug.Log("t"+masterslider.value);
        }
        FindObjectOfType<OptionsMenu>().SetVolume(menuvalue);
        if (menuvalue != menuslider.value)
        {
            FindObjectOfType<OptionsMenu>().SetVolume(menuslider.value);
        }

    }
}
