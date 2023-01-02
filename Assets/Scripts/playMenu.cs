using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject GGMenu;

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
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }


}
