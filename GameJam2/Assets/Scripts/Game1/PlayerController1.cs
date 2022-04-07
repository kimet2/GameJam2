using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour
{
    public float jump;
    public float deathJump;

    public bool timerIsRunnning = false;
    public float time = 0;

    public Text timer;

    public AudioClip jumpFX;
    public AudioClip MarioDeathFX;
    public AudioClip LuigiDeathFX;

    private Rigidbody2D rb2d;
    
    private Animator animator;

    private AudioSource audio_source;

    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator>();
        audio_source = GetComponent<AudioSource>();
        timerIsRunnning = true;
        timer.text = time.ToString("f0");
    }

    // Update is called once per frame
    void Update()
    {
        float moveVertical = Input.GetAxis ("Vertical");

        if (name == "Mario" && Input.GetKeyDown("up") && rb2d.velocity.y == 0.0f)
        {
            rb2d.AddForce(new Vector2(0.0f, jump));
            audio_source.PlayOneShot(jumpFX);
            animator.SetInteger("State",1);
        }else if (name == "Luigi" && rb2d.velocity.y == 0.0f && Input.GetKeyDown(KeyCode.I))
        {
            rb2d.AddForce(new Vector2(0.0f, jump));
            audio_source.PlayOneShot(jumpFX);
            animator.SetInteger("State",1);
        }else
        {
            animator.SetInteger("State",0);
        }

        if (timerIsRunnning)
        {
            timer.text = time.ToString("f0");
            time += Time.deltaTime;
        }else{
            timerIsRunnning = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Tronco"))
        {
            if (name == "Mario"){
                animator.Play("MarioDeath");
                audio_source.PlayOneShot(MarioDeathFX);
                rb2d.velocity = new Vector2(0, deathJump);
                rb2d.gravityScale = 0;
            }
            else if (name == "Luigi"){
                animator.Play("LuigiDeath");
                audio_source.PlayOneShot(LuigiDeathFX);
                rb2d.velocity = new Vector2(0, deathJump);
                rb2d.gravityScale = 0;
                
            }
        }
    }

}
