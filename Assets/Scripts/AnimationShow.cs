using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationShow : MonoBehaviour
{
    public GameObject skipMenu;

    public void GoToMainPage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void OpenSkip()
    {
        skipMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Close()
    {
        skipMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
