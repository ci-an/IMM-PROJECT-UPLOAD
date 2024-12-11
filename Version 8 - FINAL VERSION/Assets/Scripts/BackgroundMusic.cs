using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource backgroundMusic; //Reference to the background music

    private void Awake() {
    
        //If there is more than one background music instance, destroy this one
        if (FindObjectsOfType<BackgroundMusic>().Length > 1) {
            Destroy(gameObject);
        }
        else {
            //Make the object persistent across scenes
            DontDestroyOnLoad(gameObject);
        }

        //Play background music if it's not already playing
        if (backgroundMusic != null && !backgroundMusic.isPlaying) {
                backgroundMusic.Play();
        }
    }

    //This function can be used to stop or restart the background music if needed
    public void PlayBackgroundMusic() {
        if (backgroundMusic != null && !backgroundMusic.isPlaying) {
                backgroundMusic.Play();
        }
    }
}