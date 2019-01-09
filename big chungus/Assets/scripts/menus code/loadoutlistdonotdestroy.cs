using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadoutlistdonotdestroy : MonoBehaviour {

    
    public List<string> loadout = new List<string>();
    public List<string> loadoutDefault = new List<string>() { "Thunderbuttonenable", "fireballbuttonenable", "iciclebuttonenable", "icewallbuttonenable", "Fireblazebuttonenable", "Poisonbuttonenable" };
    public int number = 0;
    public static GameObject instance;
    float value;
    float menuvalue;
    public Slider masterslider;
    public Slider menuslider;
    public float firstvalue;
    public float secvalue;
    Scene scene;
    // Use this for initialization
    void Awake()
    {

         if (instance == null)
         {
             instance = gameObject;
         }
         else
         {
             Destroy(gameObject);
             return;
         }
        DontDestroyOnLoad(gameObject);
        number = FindObjectOfType<LoadoutList>().number;
        loadout = FindObjectOfType<LoadoutList>().loadout;
       
    }

    public void takelist()
    {
        loadout = FindObjectOfType<LoadoutList>().loadout;
        number = FindObjectOfType<LoadoutList>().number;
    }
    


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*if (scene.name == "menu")
        {
            Debug.Log("t");
            masterslider = GameObject.Find("MasterSlider").GetComponent<Slider>();
            menuslider = GameObject.Find("MenuSlider").GetComponent<Slider>();
            FindObjectOfType<OptionsMenu>().SetVolume(value);
            if (value != masterslider.value)
            {
                FindObjectOfType<OptionsMenu>().SetVolume(masterslider.value);
            }
            FindObjectOfType<OptionsMenu>().SetVolume(menuvalue);
            if (menuvalue != menuslider.value)
            {
                FindObjectOfType<OptionsMenu>().SetVolume(menuslider.value);
            }
        }    */  
    }
}
