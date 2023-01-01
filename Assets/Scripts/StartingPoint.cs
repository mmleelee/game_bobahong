using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPoint : MonoBehaviour
{
    public static bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        isStart = false;

    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            isStart = true;
        }
    }
}
