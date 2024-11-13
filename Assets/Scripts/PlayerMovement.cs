using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float horizontal;
    private Animator anim;

    [SerializeField] private float runSpeed = 10.0f;
    [SerializeField] private float jumpForce = 5.0f;
    //public CoinManager cm;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(horizontal * runSpeed * Time.deltaTime, 0, 0);
        if (horizontal > 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        if (horizontal < 0)
        {
            anim.SetBool("WalkL", true);
        }
        else
        {
            anim.SetBool("WalkL", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.0001)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }*/
}