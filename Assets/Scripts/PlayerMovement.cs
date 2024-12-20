using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour{

    private Rigidbody2D rb;
    private float horizontal;
    private Animator anim;

    [SerializeField] private float runSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;

    //contador de anillos
    public TextMeshProUGUI txtContador;
    private int Contador;

    //anillo
    public GameObject anillo;

    //reproducir sonidos
    AudioSource sonidosJuego;
    public AudioClip moneda;
    public AudioClip salto;
    public AudioClip gameover;
    //public AudioClip win;

    //ganaste, perdiste
    public GameObject ganaste;
    public GameObject perdiste;

    //tiempo
    public TextMeshProUGUI txtTimer;
    private float timeValue;


    public TextMeshProUGUI vida1;
    //private float vida;
    public float vidaActual;
    public float vidaMaxima;

    public GameObject canvas2;
    public GameObject canvas1;
    public GameObject canvas3;
    //public GameObject win;

    //public AudioSource win;

    public PauseMenuManager music;

    private bool canvas;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        anillo.gameObject.SetActive(true);
        sonidosJuego = GetComponent<AudioSource>();

        timeValue = 50;

        Contador = 0;

        ganaste.gameObject.SetActive(false);
        perdiste.gameObject.SetActive(false);
        vidaMaxima = 3;
        vidaActual = vidaMaxima;

        //camera.gameObject.SetActive(false);
        //win.Stop();
       canvas1.gameObject.SetActive(true);
        canvas2.gameObject.SetActive(false);
        canvas3.gameObject.SetActive(false);
    }

    void Update(){
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(horizontal * runSpeed * Time.deltaTime, 0, 0);

        txtContador.text = "" + Contador; //score

        vida1.text = "" + vidaActual;

        timeValue -= Time.deltaTime;
       
        txtTimer.text = FormatearTiempo(timeValue);

        string FormatearTiempo(float timeValueo){

            //Formateo minutos y segundos a dos d�gitos
            string minutos = Mathf.Floor(timeValue / 60).ToString("00");
            string segundos = Mathf.Floor(timeValue % 60).ToString("00");

            //Devuelvo el string formateado con : como separador
            return "Time:" + minutos + ":" + segundos;
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
            //anim.SetBool("Jump", true);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            sonidosJuego.PlayOneShot(salto);
        }
        // Set Jump animation based on vertical velocity
        if (Mathf.Abs(rb.velocity.y) > 0.85f){
            anim.SetBool("Jump", true); // Player is in the air
        }
        else{
            anim.SetBool("Jump", false); // Player is on the ground
        }

        /* 
         if(canvas == true){
             canvas2.gameObject.SetActive(true);
             canvas1.gameObject.SetActive(false);
         }

         if (canvas == false){
             canvas2.gameObject.SetActive(false);
             canvas1.gameObject.SetActive(true);
         }
         */
        if (Contador == 31){
            //Destroy(gameObject);
            //camera.gameObject.SetActive(true);
            // win.Play();
           canvas2.gameObject.SetActive(true);
            canvas1.gameObject.SetActive(false);
            canvas3.gameObject.SetActive(false);

            ganaste.gameObject.SetActive(true);
            music.Sonido();
            //canvas = true;
           //sonidosJuego.PlayOneShot(win);
            runSpeed = 0;
            jumpForce = 0;
            //anim.SetBool("Run", false);
            //anim.SetBool("RunL", false);
            Time.timeScale = 0;
            //anim.SetBool("Idle", false);
            txtTimer.gameObject.SetActive(false);
        }

        if (timeValue <= 0){
            Time.timeScale = 0;
            //Destroy(gameObject);
            //SceneManager.LoadScene("ganaste");
            //sonidosJuego.PlayOneShot(moneda);
            canvas3.gameObject.SetActive(true);
            canvas1.gameObject.SetActive(false);
            canvas2.gameObject.SetActive(false);
            perdiste.gameObject.SetActive(true);
            //perdiste.gameObject.SetActive(true);
            runSpeed = 0;
             jumpForce = 0;
            //anim.SetBool("Run", false);
            //anim.SetBool("RunL", false);
            txtTimer.gameObject.SetActive(false);
        }

        if (vidaActual <= 0){

            Time.timeScale = 0;
            //Destroy(gameObject);
            //SceneManager.LoadScene("ganaste");
            //sonidosJuego.PlayOneShot(moneda);
            canvas3.gameObject.SetActive(true);
            canvas1.gameObject.SetActive(false);
            canvas2.gameObject.SetActive(false);
            perdiste.gameObject.SetActive(true);
            //perdiste.gameObject.SetActive(true);
            runSpeed = 0;
            jumpForce = 0;
            //anim.SetBool("Run", false);
            //anim.SetBool("RunL", false);
            txtTimer.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("ring")){
            //anillo.gameObject.SetActive(false);

            Destroy(other.gameObject);
            Contador += 1;
            sonidosJuego.PlayOneShot(moneda);
        }
        if (other.gameObject.tag == "collider"){

            transform.position = new Vector3(-6, -2, 0);
            vidaActual -= 1;
        }
    }
}