using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePage : MonoBehaviour
{
    
    public AudioSource backAudio;

    public void GoBackMain()
    {
        Destroy(GameObject.Find("Audio Source 2"));
        backAudio.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void GoToNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

}
