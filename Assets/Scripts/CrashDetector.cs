using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delaytime = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;


    void OnTriggerEnter2D(Collider2D other)
    { 
        
        if(other.tag == "Ground" && hasCrashed == false )
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls(); 
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            crashEffect.Play();
            Invoke("ReloadScene",delaytime);

        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
