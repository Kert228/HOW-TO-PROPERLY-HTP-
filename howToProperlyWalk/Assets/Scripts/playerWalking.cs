using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWalking : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidbody;
    private float moveInput;
    private SpriteRenderer sprRend;
    private Animator animator;
    public GameObject particle;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        sprRend = gameObject.GetComponent<SpriteRenderer>();

        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
           
        rigidbody.velocity = new Vector2(moveInput * speed, rigidbody.velocity.y);

        if (moveInput > 0f)
        {
            sprRend.flipX = false;
        }else if (moveInput < 0f){
            sprRend.flipX = true;
        }

        if (moveInput != 0)
        {
            animator.SetBool("walking", true);
            Instantiate(particle,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),Quaternion.identity);
        }else{
            animator.SetBool("walking", false);
        }
        
    }
}