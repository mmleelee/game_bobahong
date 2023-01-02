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
    private float distance;
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

        // if (distance < distanceBetween && !isInStraw && StartingPoint.isStart) {
        //     if(transform.position.y >= player.transform.position.y + 5) {
        //         transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        //     } else {
        //         transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.transform.position.x, player.transform.position.y + 5), speed * Time.deltaTime);
        //     }
        // } 
        // else {
        //     transform.position = Vector2.MoveTowards(this.transform.position, pos.position, speedBack * Time.deltaTime);
        // } 

        if (ChaseArea.chase && !isInStraw && StartingPoint.isStart) {
            if(transform.position.y >= player.transform.position.y + 5) {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            } else {
                transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.transform.position.x, player.transform.position.y + 5), speed * Time.deltaTime);
            }
        } 
        else {
            transform.position = Vector2.MoveTowards(this.transform.position, pos.position, speedBack * Time.deltaTime);
        } 

        // if (StartingPoint.isStart){
        //     if (distance < distanceBetween && !isInStraw) {
                
        //         if (transform.position.y >= player.transform.position.y + 5) {
        //                 if (ChaseArea.chase) {
        //                     transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        //                 } else {
        //                     transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(pos.position.x + 5, player.transform.position.y), speed * Time.deltaTime);
        //                 }
        //         } else {
        //             if (ChaseArea.chase) {
        //                 transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.transform.position.x, player.transform.position.y + 5), speed * Time.deltaTime);
        //             } else {
        //                 transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(pos.position.x + 5, player.transform.position.y + 5), speed * Time.deltaTime);
        //             }
                        
        //         }
        //     } else {
        //         transform.position = Vector2.MoveTowards(this.transform.position, pos.position, speedBack * Time.deltaTime);
        //     } 
        // } else {
        //         transform.position = Vector2.MoveTowards(this.transform.position, pos.position, speedBack * Time.deltaTime);
        // } 
        

        
    }

}
