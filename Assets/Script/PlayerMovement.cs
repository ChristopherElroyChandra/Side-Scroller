using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 3f;
    
    private Rigidbody2D rb;
   
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        // Ambil komponen rigidbody dari objek player
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    #region AnimationHandler
    private Animator animator;
    private void PlayWalk()
    {
        animator.SetTrigger("isWalk");
    }
    private void PlayJump()
    {
        animator.SetTrigger("isJump");
    }
    #endregion
 
    private void SpriteFlip(float horizontalInput)
    {
        if (horizontalInput < 0) 
        {
            spriteRenderer.flipX = false;
        }  
        else 
        {
            spriteRenderer.flipX = true;
        }
    }

    void Update()
    {
        // Menggerakan player ke kanan atau kiri menggunakan transform.translate
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
        SpriteFlip(horizontalInput);
 
    
        // Mengaktifkan lompatan player jika player menyentuh tanah
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            PlayJump();
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            
        }
    }
}