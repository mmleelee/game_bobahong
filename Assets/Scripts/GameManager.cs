using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false; 

    public float restartDelay = 1f;
    public GameObject gameOverScreen;
    public GameObject WinScreen;

    public void EndGame () {
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void EndGame1()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
            WinScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void Restart () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
