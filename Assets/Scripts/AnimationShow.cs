using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class AnimationShow : MonoBehaviour
{
    public GameObject skipMenu;

    VideoPlayer playVideo = new VideoPlayer();

    void Start()
    {
        playVideo = GetComponent<VideoPlayer>();
        //playVideo.playOnAwake = false;
    }

    public void GoToMainPage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void OpenSkip()
    {
        playVideo.Pause();
        skipMenu.SetActive(true);
    }

    public void Close()
    {
        skipMenu.SetActive(false);
        playVideo.Play();
    }
}
