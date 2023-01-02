using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Audio;


public class mainmenu : MonoBehaviour
{
    public AudioSource btnAudio;
    public AudioSource mainAudio;
<<<<<<< HEAD

 

    //VideoPlayer playVideo = new VideoPlayer();
    //<<<<<<< HEAD
    //    public void PlayButton()
    //    {
    //        btnAudio.Play();
    //    }//按鈕音效


=======
//<<<<<<< HEAD
    public void PlayButton()
    {
        btnAudio.Play();
    }//按鈕音效
>>>>>>> d5ab559 (modify bg music)

    public void PlayGame()
    {
        //btnAudio.Play();
<<<<<<< HEAD
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
=======
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
//=======

    // public void PlayButton()
    // {
       
    // }//按鈕音效

   

//     public void PlayGame()
//     {
//         btnAudio.Play();
//         if(!btnAudio.isPlaying){
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
//         }
        
// >>>>>>> 59b7ccd (add main audio)
        
>>>>>>> d5ab559 (modify bg music)
    }
        //=======

        //    // public void PlayButton()
        //    // {

        //    // }//按鈕音效



        //    public void PlayGame()
        //    {
        //        btnAudio.Play();
        //        if(!btnAudio.isPlaying){
        //            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        //        }

        //>>>>>>> 59b7ccd (add main audio)

        //    }

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
