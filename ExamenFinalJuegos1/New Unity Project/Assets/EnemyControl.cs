using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [Header("Enemy Type Variables")]
    public string enemyType;

    [Header("Enemy Movement Variables")]
    public float speedXMovement;
    public float speedYMovement;
    public float xDirection;
    public float yDirection;

    [Header("Other Variables")]
    private Rigidbody2D rbEnemy;
    private SpriteRenderer sprRendEnemy;

     [Header("Enemy Container Variables")]
    public EnemiesContainerControl enemyContainer;

     [Header("Enemy Score Variables")]
    public int scoreToAdd;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetInitialVariables(string typ,float directionX,float directionY, Sprite spr, int sco, EnemiesContainerControl enemCont)
    {
        GetComponents();
        enemyType = typ;
        sprRendEnemy.sprite = spr;
        xDirection = directionX * -1;
        yDirection = directionY;
        scoreToAdd = sco;
        enemyContainer = enemCont;
        if(yDirection != 0){
            this.gameObject.layer = LayerMask.NameToLayer("EnemyVertical");
            rbEnemy.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public void FixedUpdate()
    {
        if(yDirection == 0){
        rbEnemy.velocity = new Vector2(
                    xDirection * speedXMovement, rbEnemy.velocity.y);
        }else{
              rbEnemy.velocity = new Vector2(
                    rbEnemy.velocity.x,  yDirection * speedYMovement);
        }
    }

    void GetComponents()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        sprRendEnemy = GetComponent<SpriteRenderer>();
    }

     void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Shoot"){
            ShootControl shootTmp;
            shootTmp = other.gameObject.GetComponent<ShootControl>();
            if(shootTmp.shootType == enemyType){
                 enemyContainer.gm.UpdateScore(scoreToAdd);
                 Destroy(other.gameObject);
                 Destroy(this.gameObject);
            }else{
                Destroy(other.gameObject);
            }
           
        }
    }
}
