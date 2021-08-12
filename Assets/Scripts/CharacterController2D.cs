using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController2D: MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed;
    [SerializeField]
    float smooth;
    [SerializeField]
    float distanceToGround;
    [SerializeField]
    float jumpPower;
    float x;
    [SerializeField]
    float powerUpTime;
    RaycastHit2D hit;

    [SerializeField]
    //float maxJumpCount;
   
    //------------------------
    Rigidbody2D rb2d;
    Animator anim;
   
    //------------------------
    SpriteRenderer flipX;
    //------------------------
    [SerializeField]
    LayerMask groundLayer;
    public Collider2D Feet;
    //------------------------
    AudioSource source;
    public AudioClip powerUpSound;
    public AudioClip healthSound;
    [SerializeField]
    bool isGrounded;
    GameObject coin;
    public GameObject level2Door;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        flipX = GetComponentInChildren<SpriteRenderer>();
        source = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        FlipFace();
        Jumping();
        OpenDoorForNextLevel();


    }
    private void FixedUpdate()
    {
        Moving();
    }
    void FlipFace()
    {
        if (x > 0)
        {
            flipX.flipX = false;
        }

        else if (x < 0)
        {
            flipX.flipX = true;
        }
    }
    void Moving()
    {
        x = Input.GetAxisRaw("Horizontal");
        Vector2 targetVeloicty = new Vector2(x * speed, rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVeloicty, ref targetVeloicty, Time.deltaTime * smooth);
        anim.SetFloat("IsRunning", Mathf.Abs(x));
    }
    void Jumping()
    {
        hit = Physics2D.BoxCast(Feet.GetComponent<Collider2D>().bounds.center,Feet.GetComponent<Collider2D>().bounds.size,0f,Vector2.down,distanceToGround,groundLayer);
        //Debug.DrawRay(feet.transform.position, Vector2.down, Color.red, distanceToGround);
        //isGrounded = Feet.IsTouchingLayers(groundLayer);
       if (hit.collider != null)
        {


           isGrounded = true;


        }
       else 
        {
            isGrounded = false;
       

       }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)//|| Input.GetKeyDown(KeyCode.Space) && maxJumpCount > 0
        {

            //maxJumpCount--;
            anim.SetBool("IsJumping",true);
            rb2d.AddForce(Vector2.up * jumpPower);
            
        }

        



    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
            source.PlayOneShot(powerUpSound);
            gameObject.tag = "inPowerUpMode";
            gameObject.GetComponentInChildren<SpriteRenderer>().material.color = Color.green; 
            StartCoroutine("PowerUpReset");
        }
        if (collision.gameObject.CompareTag("RZONE"))
        {
            if(SceneManager.sceneCount==1)
            {
                SceneManager.LoadScene(0);
            }
            else if(SceneManager.sceneCount == 2)
            {
                SceneManager.LoadScene(1);
            }
            
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        // 
        if (collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool("IsJumping", false);
            //maxJumpCount = 2f;
        }
    }

    IEnumerator PowerUpReset()
    {
        yield return new WaitForSeconds(powerUpTime);
        gameObject.tag = "Player";
        gameObject.GetComponentInChildren<SpriteRenderer>().material.color = Color.white;

    }
   public void HealthSound()
    {
        source.PlayOneShot(healthSound);
    }
    
   void OpenDoorForNextLevel()
    {
        coin = GameObject.FindGameObjectWithTag("Coin");
        
        if(coin==null&&SceneManager.sceneCount==1)
        {
            Debug.Log(" level 2 is ready");
         
            level2Door.gameObject.SetActive(true);
        }

    }
}
