using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPage : MonoBehaviour
{
    public void GoToNext()
    {
        Destroy(GameObject.Find("Audio Source 2"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
