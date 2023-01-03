using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseArea : MonoBehaviour
{
    public static bool chase;
    // Start is called before the first frame update
    void Start()
    {
        chase = true;
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            chase = false;
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            chase = true;
        }
    }
}
