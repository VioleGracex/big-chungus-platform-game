using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{

    string lvlname=" ";

    public void PlayGame()
	{
        if(lvlname==" ")
        {

        }
        else
        {
            SceneManager.LoadScene(lvlname);
        }
		
	}

    /*public void ChangeToggle()
    {
        myToggle.isOn = !myToggle.isOn;
    }*/

    public void togglename(string chosenlvl)
    {
        lvlname = chosenlvl;
    }

    public void QuitGame()
	{
		Debug.Log("Quit!");
		Application.Quit ();
	}
    void Update()
    {

    }
}
