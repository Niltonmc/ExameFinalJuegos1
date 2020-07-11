using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{

    [Header("Shoot Type Variables")]
    public string shootType;

    [Header("Movement Variables")]
    public float directionMovement;
    public float speedXMovement;

     [Header("Other Variables")]
    private Rigidbody2D rbShoot;
    private SpriteRenderer sprRendShoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
         rbShoot.velocity = new Vector2(
            directionMovement * speedXMovement, rbShoot.velocity.y);
    }

    public void SetShootVariables(string typ, Sprite spr, float dir){
       GetComponents();
        shootType = typ;
        sprRendShoot.sprite = spr;
        directionMovement = dir;
    }

     void GetComponents()
    {
        rbShoot = GetComponent<Rigidbody2D>();
        sprRendShoot = GetComponent<SpriteRenderer>();
    }
}
