using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boba_controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private bool isHurt;
    private bool cannotMove;
    int flag = 1;
    public bool jumpPressed, crouchPressed;
    public bool standIsAble;

    public int jumpCount;

    public Collider2D circlecoll;
    public Collider2D squarecoll;
    public Collider2D squashedcoll;
    public LayerMask ground;
    public Transform cellingCheck;
    public Transform groundCheck;
   

    public AudioSource jumpAudio;
    public AudioSource collAudio;
    public AudioSource candleAudio;
    public AudioSource honeyAudio;
    public AudioSource appleAudio;

    public Image EmptyeggImage;
    public Sprite eggImage;
    public Image EmptytailImage;
    public Sprite tailImage;
    public Image EmptyginsengImage;
    public Sprite ginsengImage;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
   
    public bool candle_acttime=false;
    public bool honey_acttime=false;
    public bool apple_acttime=false;

    public bool isJump, isGround, isCrouch;

    public int Cherry;

    public float jumpforce;
    public float speed;
    public float initialSpeed=400;
    public float timer=0;

    public float candleCurrentTime;
    public float honeyCurrentTime;
    public float appleCurrentTime;

    public float facedirection;
    public float horizontalMove;

    

   
    //測試用
    // public bool flag=false;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        circlecoll = GetComponent<Collider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    
     void Update()
    {
        timer += Time.deltaTime;

        //跳躍按鈕偵測 - 一般狀態
        if(Input.GetButtonDown("Jump") && jumpCount > 0 && !apple_acttime){
            jumpPressed = true;
        }

        //跳躍按鈕偵測 - 毒蘋果狀態
        else if(Input.GetButtonDown("Jump") && apple_acttime ){
            crouchPressed = true;
        }
        else if(Input.GetButtonUp("Jump") && apple_acttime){
            crouchPressed = false;
        }
        if(!Physics2D.OverlapCircle(cellingCheck.position,0.2f,ground) && apple_acttime)
        {
            standIsAble = true;
        }
        else if(Physics2D.OverlapCircle(cellingCheck.position,0.2f,ground) && apple_acttime)
        {
            standIsAble = false;
        }

        //蹲下按鈕偵測 - 一般狀態
        if(!Physics2D.OverlapCircle(cellingCheck.position,0.2f,ground) && !apple_acttime)
        {
            standIsAble = true;
        }
        else if(Physics2D.OverlapCircle(cellingCheck.position,0.2f,ground) && !apple_acttime)
        {
            standIsAble = false;
        }

        if(Input.GetButtonDown("Down") && !apple_acttime)
        {
            crouchPressed = true;
        }
        else if(Input.GetButtonUp("Down") && !apple_acttime)
        {
            crouchPressed = false;
            
        }
        //蹲下按鈕偵測 - 毒蘋果狀態
        else if(Input.GetButtonDown("Down") && apple_acttime && jumpCount > 0)
        {
            jumpPressed = true;
        }
        else if(Input.GetButtonUp("Down") && apple_acttime && jumpCount > 0)
        {
            jumpPressed = false;
        }
        CheckStatus();
    }
   
    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);
        if(!isHurt && !cannotMove){
            Movement();
        }
        Jump();
        // if(Input.GetButtonDown("Jump") && jumpCount > 0 && !apple_acttime)
        // {
        //     jumpPressed = true;
        //     Jump();
        // }
        Crouch();
        SwitchAnim();
    }

    //-------------------------------------------道具函式---------------------------
    void CandleMovement()
    {
        if((timer-candleCurrentTime)<5){
            speed=initialSpeed*2;
            anim.SetBool("iscandle" , true);
        }
        else {
            candle_acttime = false;
            anim.SetBool("iscandle" , false);
        }
    }//控制道具蠟燭

    void HoneyMovement()
    {
        if((timer-honeyCurrentTime)<5){
            speed=initialSpeed/2;
            jumpforce=jumpforce/2;
            anim.SetBool("ishoney" , true);
        }
        else {
            honey_acttime=false;
            anim.SetBool("ishoney" , false);
        }
     }//控制道具壞蜂巢

    void AppleMovement()
    {
        if((timer-appleCurrentTime)<5){
            facedirection = -(facedirection);
            horizontalMove = -(horizontalMove);

            anim.SetBool("isapple" , true);
            flag = 1;

            // if(!Physics2D.OverlapCircle(cellingCheck.position,0.2f,ground)){
            //     if(Input.GetButton("Jump") ){
            //         anim.SetBool("crouching" , true);//蹲下動畫
            //         circlecoll.enabled = false;
            //         squarecoll.enabled = true;
            //     }

            //     if(Input.GetButtonUp("Jump") ){
            //         anim.SetBool("crouching" , false);
            //         circlecoll.enabled = true;
            //         squarecoll.enabled = false;
            //     }
            // }//up->蹲下

            // if(Input.GetButton("Down") ){
            //     rb.velocity = new Vector2( rb.velocity.x , jumpforce * Time.fixedDeltaTime);
            //     jumpAudio.Play();//播放跳躍音效
            //     anim.SetBool("jumping" , true);//跳躍動畫
            // }
        }

        else {
            apple_acttime=false;
            anim.SetBool("isapple" , false);
             if(anim.GetBool("crouching")==false){
                isCrouch=false;
            }
        }
     }//控制道具毒蘋果


    //-------------------------------------------角色移動---------------------------
    void Movement()
    {
        horizontalMove= Input.GetAxis("Horizontal");
        facedirection = Input.GetAxisRaw("Horizontal");

        speed=initialSpeed;

        if(candle_acttime) CandleMovement();
        else if(honey_acttime) HoneyMovement();
        else if(apple_acttime) AppleMovement();

        if(horizontalMove != 0 ){
            rb.velocity = new Vector2( horizontalMove * speed * Time.fixedDeltaTime, rb.velocity.y);
            anim.SetFloat("walking" , Mathf.Abs(facedirection));//走路動畫
        }//左右移動

        if(facedirection != 0 ){
            transform.localScale = new Vector3( facedirection  , 1,1);
        }//面向左右

        // if(Input.GetButtonDown("Jump") && !apple_acttime){
        //      rb.velocity = new Vector2( rb.velocity.x , jumpforce * Time.fixedDeltaTime);
        //      jumpAudio.Play();//播放跳躍音效
        //      anim.SetBool("jumping" , true);//跳躍動畫
        // }//跳躍

        //Crouch();
    }

     //-------------------------------------------跳躍設定---------------------------

    void Jump()
    {
        if(isGround)
        {
            jumpCount = 1;
            isJump = false;
        }
        if(jumpPressed && isGround)
        {
            isJump = true;
            jumpAudio.Play();//播放跳躍音效
            rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.fixedDeltaTime);
            jumpCount--;
            jumpPressed = false;
            anim.SetBool("jumping",true);
        }
        else if(jumpPressed && jumpCount > 0 && isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.fixedDeltaTime);
            jumpCount--;
            jumpPressed = false;
            anim.SetBool("jumping",true);
        }
    }
   

    //-------------------------------------------蹲下設定---------------------------
    void Crouch()
    {
        if(isCrouch == false && crouchPressed == true){
            anim.SetBool("crouching" , true);//蹲下動畫
            circlecoll.enabled = false;
            squarecoll.enabled = true;
            isCrouch = true;
        }

        else if(isCrouch == true && crouchPressed == false){
            if(standIsAble){
                anim.SetBool("crouching" , false);//蹲下動畫
                anim.SetBool("stand" , true);//站立動畫
                circlecoll.enabled = true;
                squarecoll.enabled = false;
                isCrouch = false;
            }
        }
    }
    // void Crouch(){
    //     if(!Physics2D.OverlapCircle(cellingCheck.position,0.2f,ground))
    //     {
    //          if(Input.GetButton("Down") ){
    //             anim.SetBool("crouching" , true);//蹲下動畫
    //             circlecoll.enabled = false;
    //             squarecoll.enabled = true;
    //          }

    //         if(Input.GetButtonUp("Down") ){
    //             anim.SetBool("crouching" , false);
    //             //anim.SetBool("stand" , true);//站立動畫
    //             circlecoll.enabled = true;
    //             squarecoll.enabled = false;
    //         }
    //     }
       
    // }//蹲下

    //-------------------------------------------切換動畫---------------------------
    void SwitchAnim()
    {
        anim.SetBool("stand" , false);

         //落下狀態
        if(rb.velocity.y < 0.1 && !isGround) //
        {
            anim.SetBool("falling", true);
        }

        if(anim.GetBool("jumping")){
            if(rb.velocity.y < 0){
                anim.SetBool("jumping" , false);
                anim.SetBool("falling" , true);
            }
        }//跳躍後降落動畫

         else if(isHurt)
        {
            //anim.SetBool("hurt",true);
            anim.SetFloat("running",0);
            if(Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                anim.SetBool("hurt",false);
                anim.SetBool("stand",true);
                isHurt = false;
            }//從受傷狀態回復
        }

        else if(isGround){
            anim.SetBool("falling" , false);
            anim.SetBool("stand" , true);
        }//判斷降落地面轉為站立動畫
    }

 

    //-------------------------------------------物品蒐集---------------------------
    private void  OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Collection_egg"){
            collAudio.Play();//播放收集音效
            Destroy(collision.gameObject);
            EmptyeggImage.sprite = eggImage;
        }//顯示蛋

        else if(collision.tag == "Collection_tail"){
            collAudio.Play();//播放收集音效
            Destroy(collision.gameObject);
            EmptytailImage.sprite = tailImage;
        }//顯示尾巴

        else if(collision.tag == "Collection_ginseng"){
            collAudio.Play();//播放收集音效
            Destroy(collision.gameObject);
            EmptyginsengImage.sprite = ginsengImage;
        }//顯示人蔘


        //-------------------------------------------觸碰道具---------------------------

        else if(collision.tag == "props_candle"){
            candleAudio.Play();//播放加速音效
            Destroy(collision.gameObject);
            candleCurrentTime=timer;
            candle_acttime=true;
            
        }//道具蠟燭
        
        else if(collision.tag == "props_honey"){
            honeyAudio.Play();//播放減速音效
            Destroy(collision.gameObject);
            honeyCurrentTime=timer;
            honey_acttime=true;
                
        }//道具壞蜂巢

        else if(collision.tag == "props_apple"){
            appleAudio.Play();//播放壞道具音效
            Destroy(collision.gameObject);
            appleCurrentTime=timer;
            apple_acttime=true;
       
        }//道具壞蘋果
        
    }


    //-------------------------------------------消滅敵人---------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(anim.GetBool("falling")){
            if(collision.gameObject.tag == "Ant" || collision.gameObject.tag == "Cookie"){
                Destroy(collision.gameObject);
                rb.velocity = new Vector2( rb.velocity.x , jumpforce * Time.fixedDeltaTime);
                anim.SetBool("jumping", true);
            }
        }
        else if(collision.gameObject.tag == "Ant"){
            if(transform.position.x < collision.gameObject.transform.position.x){
                rb.velocity = new Vector2(-5, rb.velocity.y);
                isHurt = true;
            }
            else if(transform.position.x > collision.gameObject.transform.position.x){
                rb.velocity = new Vector2(5, rb.velocity.y);
                isHurt = true;
            }
        }
        else if(collision.gameObject.tag == "Cookie"){
            if(transform.position.x < collision.gameObject.transform.position.x){
                isHurt = true;
                anim.SetBool("squashed",true);
                squarecoll.enabled = false;
                circlecoll.enabled = false;
                squashedcoll.enabled = true;
                cannotMove = true;
                FindObjectOfType<GameManager>().EndGame(); 
            }
        }

        //被吸走死掉
        if (collision.gameObject.tag == "Straw") {
            FindObjectOfType<GameManager>().EndGame(); 
        }
    }

    void CheckStatus()
    {
        if(flag == 1 && Input.GetButtonUp("Jump"))
        {
            crouchPressed = false;
            flag = 0;
        }
    }
   
}


