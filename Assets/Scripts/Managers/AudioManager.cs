using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public UnityEngine.UI.Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume", 1f);
            Load();
        } else {
            Load();
        }
    }

    public void ChangeVolume(){
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load(){

        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        ChangeVolume();
    }

    private void Save(){
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
