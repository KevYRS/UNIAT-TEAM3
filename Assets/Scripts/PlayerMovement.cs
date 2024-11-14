using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour{

    private Rigidbody2D rb;
    private float horizontal;
    private Animator anim;

    [SerializeField] private float runSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    //public CoinManager cm;

    //contador de anillos
    public TextMeshProUGUI txtContador;
    private int Contador;

    //anillo
    public GameObject anillo;

    //reproducir audio de recolectar anillo
    AudioSource sonidosJuego;
    public AudioClip moneda;

    //ganaste, perdiste
    public TextMeshProUGUI ganaste;
    public TextMeshProUGUI perdiste;

    //tiempo
    public TextMeshProUGUI txtTimer;
    private float timeValue;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        anillo.gameObject.SetActive(true);
        sonidosJuego = GetComponent<AudioSource>();

        timeValue = 200;

        Contador = 0;

        ganaste.gameObject.SetActive(false);
        perdiste.gameObject.SetActive(false);


    }

    void Update(){
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(horizontal * runSpeed * Time.deltaTime, 0, 0);


        txtContador.text = "" + Contador; //score


        timeValue -= Time.deltaTime;
       
       txtTimer.text = FormatearTiempo(timeValue);

        
        string FormatearTiempo(float timeValueo){

            //Formateo minutos y segundos a dos dígitos
            string minutos = Mathf.Floor(timeValue / 60).ToString("00");
            string segundos = Mathf.Floor(timeValue % 60).ToString("00");

            //Devuelvo el string formateado con : como separador
            return "Tiempo:" + minutos + ":" + segundos;

        }
        
        

        if (horizontal > 0){
            anim.SetBool("Run", true);
        }
        else{
            anim.SetBool("Run", false);
        }
        if (horizontal < 0){
            anim.SetBool("RunL", true);
        }
        else{
            anim.SetBool("RunL", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.0001){
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }






        if (Contador == 10)
        {

            //Destroy(gameObject);
            ganaste.gameObject.SetActive(true);
            runSpeed = 0;
            jumpForce = 0;
            anim.SetBool("Run", false);
            anim.SetBool("RunL", false);
            Time.timeScale = 0;
            //anim.SetBool("Idle", false);


        }



        if (timeValue == 0)
        {

            //Destroy(gameObject);
            perdiste.gameObject.SetActive(true);
            runSpeed = 0;
            jumpForce = 0;
            anim.SetBool("Run", false);
            anim.SetBool("RunL", false);
            Time.timeScale = 0;
            //anim.SetBool("Idle", false);


        }



    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ring"))
        {
            //anillo.gameObject.SetActive(false);

            Destroy(other.gameObject);
            Contador += 1;
            sonidosJuego.PlayOneShot(moneda);
           
        }
    }
}