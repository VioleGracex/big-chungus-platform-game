using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutList : MonoBehaviour {

    //public string[] loadout = new string[12];
    public int number = 0;
    public List<string> loadout = new List<string>();
    public List<string> loadoutDefault = new List<string>() { "Thunderbuttonenable", "fireballbuttonenable", "iciclebuttonenable", "icewallbuttonenable", "Fireblazebuttonenable", "Poisonbuttonenable" };
    string lastpressed=null;

    //public static GameObject instance;
    void Awake()
    {
       /* if (instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
            return;
        }*/
        //DontDestroyOnLoad(gameObject);
        //loadout[0]=(null);
    }
    // Use this for initialization
    void Start ()
    {
		
	}

  
    public void addtoloadout(string item)
    {       
            loadout.Add(item);
            number++;
            lastpressed = item;                   
    }
    public void removefromloadout(string item)
    {   
            string s = loadout.Find(load => load == item);
            int sindex = loadout.FindIndex(load => load == item);
            loadout.RemoveAt(sindex);
            number--;
            //Debug.Log(s+ sindex);
            lastpressed = null;
            //Togglevalue = false;   
        
    }
    public void DefaultLoadout()
    {
        loadout = new List<string>{ "Thunderbuttonenable", "fireballbuttonenable", "iciclebuttonenable", "icewallbuttonenable", "Fireblazebuttonenable", "Poisonbuttonenable" };
        /*if(loadout[0]==null)
        {
            loadout[0] = "Thunderbuttonenable";
            loadout[1] = "fireballbuttonenable";
            loadout[2] = "iciclebuttonenable";
            loadout[3] = "icewallbuttonenable";
            loadout[4] = "Fireblazebuttonenable";
            loadout[5] = "Poisonbuttonenable";
           
        }
        else
        {
            loadout.Add("Thunderbuttonenable");
            loadout.Add("fireballbuttonenable");
            loadout.Add("iciclebuttonenable");
            loadout.Add("icewallbuttonenable");
            loadout.Add("Fireblazebuttonenable");
            loadout.Add("Poisonbuttonenable");
        }*/
        
       
        //Debug.Log(lastpressed);
    }

    // Update is called once per frame
    void Update ()
    {
        //Debug.Log(number);
        FindObjectOfType<loadoutlistdonotdestroy>().takelist();
    }
}
