using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Cookie : MonoBehaviour
{

    private Rigidbody2D rb;
    // public Transform leftpoint;
    public Transform startPoint, player, camera;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Movement();
    }

    void Movement()
    {
        if(player.position.x >= startPoint.position.x || camera.position.x >= startPoint.position.x)
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
        }
    }
}
