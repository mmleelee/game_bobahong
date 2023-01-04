using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false; 

    public float restartDelay = 1f;
    public GameObject gameOverScreen;
    public GameObject WinScreen;

    public AudioSource failAudio;
    public AudioSource winAudio;

    

    public void EndGame () {
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Destroy(GameObject.Find("Game Audio Source"));
            failAudio = GameObject.FindGameObjectWithTag ("FailMusic").GetComponent<AudioSource> ();
            failAudio.Play();
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
            winAudio = GameObject.FindGameObjectWithTag ("WinMusic").GetComponent<AudioSource> ();
            winAudio.Play();
            Invoke("Restart", restartDelay);
            WinScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void Restart () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
