using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
//using TMPro;

public class PauseMenuButtons : MonoBehaviour 
{
	public static bool GameIsPaused = false;
	public GameObject PauseMenuUI;
	public Slider wavesnum;
    string nxtlvlname;
    int nxtlvlnum;
    bool speeded=false;
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        nxtlvlnum = int.Parse(Regex.Replace(scene.name, "[^0-9]", ""))+1;
        nxtlvlname = " lvl " + nxtlvlnum;
        //Debug.Log(nxtlvlname);
    }
	public void ResumeGame()
	{
        if(speeded==true)
        {
            Time.timeScale = 2f;
        }
        else
        {
            Time.timeScale = 1f;
        }
		
		GameIsPaused = false;
	}
	public void PauseGame()
	{
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
	public void Restartlvl()
	{
		//SceneManager.LoadScene ("loading");
		SceneManager.LoadScene ("lvl 1");
        Time.timeScale = 1f;

    }
    public void nxtlvl()
    {
        //SceneManager.LoadScene ("loading");
        SceneManager.LoadScene(nxtlvlname);
        Time.timeScale = 1f;
    }

    public void speedx2()
    {
        //SceneManager.LoadScene ("speedup");      
        Time.timeScale = 2f;
        speeded=true;

    }
    public void speedx1()
    {
        //SceneManager.LoadScene ("speeddown");      
        Time.timeScale = 1f;
        speeded = false;

    }

    public void BackToMainMenu()
	{
		SceneManager.LoadScene ("menu");
	}
	void update()
	{
		
		/*if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (GameIsPaused) 
			{
				PauseMenuUI.SetActive (false);
				ResumeGame ();
			}
			else
			{
				PauseMenuUI.SetActive (true);
				PauseGame();
			}
		}*/
		
	}
}
