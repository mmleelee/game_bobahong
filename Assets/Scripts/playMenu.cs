using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class playMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject GGMenu;
    public AudioSource bgAudio;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)==true){
            PauseGame();
        }
    }
    

    public void GoBackChoosePage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        //GGMenu.SetActive(true);
        bgAudio.Pause();
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        bgAudio.Play();
        Time.timeScale = 1f;
    }


}
