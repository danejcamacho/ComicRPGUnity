using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> musicList;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (musicList.Count > 0){
            audioSource.clip = musicList[0];
            PlayMusic();
        }
        
        
    }

    public void PlayMusic(){
        audioSource.Play();
    }
}
