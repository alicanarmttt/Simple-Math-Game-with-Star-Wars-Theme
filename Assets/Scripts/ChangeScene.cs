using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public AudioClip EntryBackGroundMusic;
    public AudioClip audioClick;
    public AudioSource EntryBackground;

    void Start()
    {
        
        EntryBackground = GetComponent<AudioSource>();
    }
    
    public void playButton()
    {
        EntryBackground.clip = audioClick;
        EntryBackground.Play();
        StartCoroutine(ContinueBackgroundMusic(audioClick.length +1));
        
    }

    
    private IEnumerator ContinueBackgroundMusic(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Game");
    }
}
