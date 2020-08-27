using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerFunMode : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 position;

    public bool onGround;
    private float jumpPressure;
    private float minJump;
    private float maxJumpPressure;

    private Rigidbody rbody;
    private Animator anim;
    private Camera cam;

    public float fadeOutTime;

    public GameObject firstTutorial;
    public GameObject secondTutorial;
    public GameObject thirdTutorial;
    public GameObject fourthTutorial;
    public LayerMask ground;

    public bool toothCollided;
    public MainMenu mainMenu;
    

    public int amountOfJumps;
    public int minutes = 0;
    public int hours = 0;
    public bool timerTrigger = true;
    public float timespent = 0.0f;
    public float seconds = 0.00f;

    public AudioSource audioSource;
    public AudioListener audioListener;
    public AudioClip[] audio_landing;

    public FunModeFadeIn fadeIn;


    public float doubleJump;
    public bool gameStarted;




    void Start()
    {
        onGround = true;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 10f;
        rbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
        amountOfJumps = 0;
        toothCollided = false;
        audioListener = GetComponent<AudioListener>();
        audioSource = gameObject.GetComponent<AudioSource>();
        gameStarted = true;

    }


    private void FixedUpdate()
    {
        checkIfGrounded();

    }
    public void Update()
    {

        if (gameStarted)
        {
            timespent += seconds;
            seconds += Time.deltaTime;
            if (seconds > 60)
            {
                minutes += 1;
                seconds = 0;
            }
            if (minutes > 60)
            {
                hours += 1;
                minutes = 0;
            }
        }



        if (Input.GetKey(KeyCode.LeftControl) && !onGround)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + doubleJump, transform.position.z);
            
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = transform.position.z - cam.transform.position.z;
        Vector3 mousePosWorld = cam.ScreenToWorldPoint(mousePos);
        Vector3 offset = mousePosWorld - transform.position;
        offset = offset.normalized;


        if (onGround)
        {
            if (Input.GetButton("Jump"))
            {
                if (jumpPressure < maxJumpPressure)
                {
                    jumpPressure += Time.deltaTime * 15f;

                }

                else
                {
                    jumpPressure = maxJumpPressure;

                }

            }

            else
            {
                if (jumpPressure > 0f)
                {

                    jumpPressure = jumpPressure + minJump;
                    rbody.AddForce(new Vector3(offset.x, offset.y, 0) * jumpPressure, ForceMode.Impulse);
            
                    jumpPressure = 0f;

                    amountOfJumps += 1;
                }
            }
        }
    }

    public void checkIfGrounded()
    {

        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 2 * 1.05f, transform.rotation, ground);
        int i = 0;

        if (i < hitColliders.Length)
        {
            onGround = true;
        }

        else
        {
            onGround = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, transform.localScale *2);
    }
    
    void OnCollisionEnter(Collision other)
     {
         if (other.gameObject.CompareTag("Ground"))
         {
            PlayRandomLandingSound();
         }
     }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("firstTutorial"))
        {
            firstTutorial.SetActive(true);
        }
        
        if (other.gameObject.CompareTag("secondTutorial"))
        {
            secondTutorial.SetActive(true);
        }

        if (other.gameObject.CompareTag("thirdTutorial"))
        {
            thirdTutorial.SetActive(true);
        }
        
        if (other.gameObject.CompareTag("fourthTutorial"))
        {
            fourthTutorial.SetActive(true);
        }

        if (other.gameObject.CompareTag("demoFinal"))
        {
            PlayerPrefs.SetInt("levelOneCleared", 1);
            PlayerPrefs.Save();
        }

        if (other.gameObject.CompareTag("toothCollider"))
        {
            toothCollided = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("firstTutorial"))
        {
            firstTutorial.SetActive(false);
        }

        if (other.gameObject.CompareTag("secondTutorial"))
        {
            secondTutorial.SetActive(false);
        }

        if (other.gameObject.CompareTag("thirdTutorial"))
        {
            thirdTutorial.SetActive(false);
        }
        
        if (other.gameObject.CompareTag("fourthTutorial"))
        {
            fourthTutorial.SetActive(false);
        }

    }

    void PlayRandomLandingSound()
    {
        audioSource.clip = audio_landing[Random.Range(0, audio_landing.Length)];
        audioSource.Play();
    }
    
}
