using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWalking : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    private Rigidbody2D rigidbody;
    private float moveInput;
    private SpriteRenderer sprRend;
    public Animator animator;
    public GameObject walkParticle;
    public bool grounded;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool isJumping;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        sprRend = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
           
        rigidbody.velocity = new Vector2(moveInput * speed, rigidbody.velocity.y);

        if (moveInput > 0f)
        {
            gameObject.transform.localScale = new Vector2 ( 1, gameObject.transform.localScale.y );
        }else if (moveInput < 0f){
            gameObject.transform.localScale = new Vector2 ( -1, gameObject.transform.localScale.y );
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("lightattack");
        }
        if (Input.GetKeyDown(KeyCode.X) && grounded == true)
        {
            animator.SetTrigger("strongattack");
        }

        if (moveInput != 0)
        {
            animator.SetBool("walking", true);
            if (grounded == true)
            {
                Instantiate(walkParticle,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),Quaternion.identity);
            }
        }else{
            animator.SetBool("walking", false);
        }

        if(Input.GetKeyDown("space") && grounded == true)
        {
            for(int i = 0;i <= 50;i++)
            {
                Instantiate(walkParticle,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),Quaternion.identity);
            }

            animator.SetTrigger("jump");
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
            grounded = false;

            jumpTimeCounter = jumpTime;
            isJumping = true;
        }

        if(Input.GetKeyUp("space"))
        {
            isJumping = false;
        }

        if(Input.GetKey("space") && grounded == false && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
                jumpTimeCounter -= Time.deltaTime;
            }else{
                isJumping = false;
            }
        }     
    }
}