using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jump;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Tronco"))
        {
            if (name == "Mario"){
                animator.SetInteger("State",2);
                audio_source.PlayOneShot(MarioDeathFX);
            }
            else if (name == "Luigi"){
                animator.SetInteger("State",2);
                audio_source.PlayOneShot(LuigiDeathFX);
            }
        }
    }

}
