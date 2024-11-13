using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float horizontal;
    private Animator anim;

    [SerializeField] private float runSpeed = 10.0f;
    [SerializeField] private float jumpForce = 5.0f;
    //public CoinManager cm;


    //public GameObject anillo;
    //AudioSource sonidosJuego;
    //public AudioClip moneda;


   // public TextMeshProUGUI txtTimer;
    //private float timeValue;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //anillo.gameObject.SetActive(true);
        //sonidosJuego = GetComponent<AudioSource>();

        //timeValue = 200;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(horizontal * runSpeed * Time.deltaTime, 0, 0);




       /* timeValue -= Time.deltaTime;
        txtTimer.text = FormatearTiempo(timeValue);



        string FormatearTiempo(float timeValueo)
        {

            //Formateo minutos y segundos a dos dígitos
            string minutos = Mathf.Floor(timeValue / 60).ToString("00");
            string segundos = Mathf.Floor(timeValue % 60).ToString("00");

            //Devuelvo el string formateado con : como separador
            return minutos + ":" + segundos;

        }


        */


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

          sonidosJuego.PlayOneShot(moneda);
        }
    }*/
}