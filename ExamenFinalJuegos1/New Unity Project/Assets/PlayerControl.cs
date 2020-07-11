using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [Header("Player Position Variables")]
    public float maxXPosition;
    public float minXPosition;
    private float currentPosX;

    [Header("Player Movement Variables")]
    public bool isMoving;
    public float speedXMovement;
    private float directionMovement;
    private float shootDirection;

    [Header("Player Jump Variables")]
    public float jumpForce;
    public bool isGrounded;
    public Transform checkGround;
    public float radiusOfGroundCheck;
    public LayerMask whatIsGround;

    [Header("Shoot Variables")]
    public List<Sprite> allShootSprites;
    public List<string> allShootTypes;
    public GameObject shootPref;
    private ShootControl shootTmp;
    private float currentTimeToShoot;
    public float timeToShoot;
    public bool canShoot;

    [Header("Lives Variables")]
    public int playerLives;

    [Header("Other Variables")]
    private Rigidbody2D rbPlayer;
    private Animator animPlayer;
    private SpriteRenderer sprRendPlayer;

    [Header("Game Manager Variables")]
    public GameManagerControl gm;

    void Awake()
    {
        GetComponents();
        playerLives = PlayerPrefs.GetInt("PlayerLives",2);
        gm.UpdateLives(playerLives);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void FixedUpdate()
    {
        Movement();
        PlayerJump();
    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isMoving = true;
            directionMovement = -1;
            shootDirection = directionMovement;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            isMoving = true;
            directionMovement = 1;
            shootDirection = directionMovement;
        }
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            directionMovement = 0;
            isMoving = false;
        }
        rbPlayer.velocity = new Vector2(
            directionMovement * speedXMovement, rbPlayer.velocity.y);
        animPlayer.SetBool("isMoving", isMoving);
        if (directionMovement == 1)
        {
            sprRendPlayer.flipX = false;
        }
        else if (directionMovement == -1)
        {
            sprRendPlayer.flipX = true;
        }

        currentPosX = Mathf.Clamp(rbPlayer.position.x, minXPosition, maxXPosition);
		rbPlayer.position = new Vector2 (currentPosX, rbPlayer.position.y);
    }

    void PlayerJump()
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.position, radiusOfGroundCheck, whatIsGround);
        if (isGrounded == true && Input.GetKey(KeyCode.UpArrow))
        {
            rbPlayer.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void Shoot()
    {
        if (canShoot == false)
        {
            currentTimeToShoot = currentTimeToShoot + Time.deltaTime;
            if (currentTimeToShoot > timeToShoot)
            {
                currentTimeToShoot = 0;
                canShoot = true;
            }
        }
        if (canShoot == true)
        {

            if (Input.GetKeyUp(KeyCode.A))
            {
                GameObject tmp = Instantiate(shootPref, transform.position, transform.rotation);
                shootTmp = tmp.GetComponent<ShootControl>();
                shootTmp.SetShootVariables("brown", allShootSprites[0], shootDirection);
                canShoot = false;

            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                GameObject tmp = Instantiate(shootPref, transform.position, transform.rotation);
                shootTmp = tmp.GetComponent<ShootControl>();
                shootTmp.SetShootVariables("cream", allShootSprites[1], shootDirection);
                canShoot = false;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                GameObject tmp = Instantiate(shootPref, transform.position, transform.rotation);
                shootTmp = tmp.GetComponent<ShootControl>();
                shootTmp.SetShootVariables("fly", allShootSprites[2], shootDirection);
                canShoot = false;
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                GameObject tmp = Instantiate(shootPref, transform.position, transform.rotation);
                shootTmp = tmp.GetComponent<ShootControl>();
                shootTmp.SetShootVariables("red", allShootSprites[3], shootDirection);
                canShoot = false;
            }

            if (Input.GetKeyUp(KeyCode.G))
            {
                GameObject tmp = Instantiate(shootPref, transform.position, transform.rotation);
                shootTmp = tmp.GetComponent<ShootControl>();
                shootTmp.SetShootVariables("yellow", allShootSprites[4], shootDirection);
                canShoot = false;
            }
        }
    }

    void GetComponents()
    {
        shootDirection = 1;
        rbPlayer = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
        sprRendPlayer = GetComponent<SpriteRenderer>();
    }

     void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy"){
            playerLives = playerLives - 1;
            gm.UpdateLives(playerLives);
            Destroy(other.gameObject);
        }
    }
}
