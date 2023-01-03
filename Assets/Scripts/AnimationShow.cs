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
       // 結束後開始遊戲
       playVideo.loopPointReached += EndReacted;
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

    // 結束後開始遊戲
    void EndReacted(VideoPlayer vp) {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
