using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SettingsMenu : MonoBehaviour
{
    void Update(){
    if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("GameScene");
        }
    }
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int curResolutionIndex = 0;
        for(int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                curResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = curResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }

public void SetQuality(int qualityIndex){

    QualitySettings.SetQualityLevel(qualityIndex);
}

public void SetFullscreen(bool isFullscreen){
    Screen.fullScreen = isFullscreen;
}

}
