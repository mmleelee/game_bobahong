using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Audio;


public class mainmenu : MonoBehaviour
{
    public AudioSource btnAudio;
    public AudioSource mainAudio;


    //VideoPlayer playVideo = new VideoPlayer();
    //<<<<<<< HEAD
    //    public void PlayButton()
    //    {
    //        btnAudio.Play();
    //    }//按鈕音效

    public void PlayGame()
    {
        //btnAudio.Play();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

       

    
    }
    

     public void QuitGame()
    {
        Application.Quit();
    }

    public void UIEnable()
    {
        GameObject.Find("Canvas/menu/UI").SetActive(true);
        //mainAudio.Play();
    }
}
