using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    public AudioMixer audiomixermenu;
    public Slider masterslider;
    public Slider menuslider;
    public Dropdown resolutionDropdown;
    public static GameObject instance;
    Resolution[] resolutions;
    float value;
    float menuvalue;
    int onetime = 0;
    // Use this for initialization

    void Awake()
    {
       
    }
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List <string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0 ; i < resolutions.Length ; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width== Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetVolume ( float volume)
    {
        audiomixer.SetFloat("MainVolume", volume);
        //Debug.Log("vol" + volume);
    }
    public void SetVolumeMenu(float volume)
    {
        audiomixermenu.SetFloat("MainVolume", volume);
        //Debug.Log("vol" + volume);
    }
    public void SetQuality ( int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    void Update()
    {
        
    }
    

}
