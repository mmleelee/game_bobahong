using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testt : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform startPoint, player;
    public Transform camera;
    // public Transform leftpoint, rightpoint;  //用來取得左右端點的變數
    // private float leftx,rightx;  //左右端點座標
    public float Speed;
    //private bool faceLeft = true;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
        // leftx = leftpoint.position.x;
        // rightx = rightpoint.position.x;
        // Destroy(leftpoint.gameObject);
        // Destroy(rightpoint.gameObject);  
    }

    // Update is called once per frame
    void Update()
    {
        AntMovement();
    }
     void AntMovement()
    {

        if(player.position.x >= startPoint.position.x || camera.position.x >= startPoint.position.x)
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
        }

        //左右來回移動
        // if(faceLeft)
        // {
        //     rb.velocity = new Vector2(-Speed, rb.velocity.y);
        //     if(transform.position.x < leftx)
        //     {
        //         transform.localScale = new Vector3(-1, 1, 1);
        //         faceLeft = false;
        //     }
        // }
        // else
        // {
        //     rb.velocity = new Vector2(Speed, rb.velocity.y);
        //     if(transform.position.x > rightx)
        //     {
        //         transform.localScale = new Vector3(1, 1, 1);
        //         faceLeft = true;
        //     }
        // }
    }
}
