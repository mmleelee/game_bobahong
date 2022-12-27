using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawEdge : MonoBehaviour
{

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Straw.isInStraw = true;
        }
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Straw.isInStraw = false;
        }
    }
}
