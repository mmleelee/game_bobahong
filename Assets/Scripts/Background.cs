using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    public float bgSpeed;
    public Renderer bgRender;

    //void Start()
    //{
       
    //}

    // Update is called once per frame
    void Update()
    {
        bgRender.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);
    }
}
