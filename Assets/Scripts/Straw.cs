using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straw : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float speedBack;
    public float distanceBetween;

    

    public Transform pos;
    //public Transform cam;
    //public float xCoordinate, yCoordinate, zCoordinate;

    private float distance;
    //private bool tooClose = false;

    public static bool isInStraw;

    // Start is called before the first frame update
    void Start()
    {
        isInStraw = false;
    }

    // Update is called once per frame 
    void Update()
    {

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        //if (distance < distanceBetween && (transform.position.y >= player.transform.position.y + 5)) {

        if (distance < distanceBetween && !isInStraw) {
            //Debug.Log(isInStraw);
            //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            if(transform.position.y >= player.transform.position.y + 5) {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            } else {
                transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.transform.position.x, player.transform.position.y + 5), speed * Time.deltaTime);
            }
        } 
        else {
            //Debug.Log(isInStraw);
            transform.position = Vector2.MoveTowards(this.transform.position, pos.position, speedBack * Time.deltaTime);
        } 

        
    }

    // void OnTriggerEnter2D (Collider2D other) {
    //     if (other.gameObject.CompareTag("Player")) {
    //         isInStraw = true;
    //         Debug.Log("in straw");
    //     }
    // }

    // void OnTriggerExit2D (Collider2D other) {
    //     if (other.gameObject.CompareTag("Player")) {
    //         isInStraw = false;
    //         Debug.Log("not in straw");
    //     }
    // }

    // void OnTriggerEnter2D (Collider2D other) {
    //     if (other.gameObject.CompareTag("AroundPlayer")) {
    //         Debug.Log("tooClose");
    //         tooClose = true;
    //     }
        
    // }
    // void OnTriggerExit2D (Collider2D other) {
    //     if (other.gameObject.CompareTag("AroundPlayer")) {
    //         Debug.Log("notTooClose");
    //         tooClose = false;
    //     }
    // }
}
