using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text timers;
    public float timeRemaining = 30;
    public bool timerIsRunning = false;

    private Rigidbody2D rb2d;
    private Animator m_animator;
        private Animator m_animator2;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_animator2 = GetComponent<Animator>();
        timerIsRunning = true;
        timers.text = timeRemaining.ToString("f0");
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
    
        if(moveHorizontal > 0)
        {
            
            m_animator.SetInteger("direccio", 0);
            transform.eulerAngles = new Vector2(0,0);
            rb2d.velocity= new Vector2(speed, rb2d.velocity.y);
        }
         else if(moveHorizontal < 0)
        {
            rb2d.velocity=new Vector2(-speed, rb2d.velocity.y);
            m_animator.SetInteger("direccio", 0);
            transform.eulerAngles = new Vector2(0,180);
        }
        
        else 
        {
            rb2d.velocity=new Vector2(0.0f, rb2d.velocity.y);
            m_animator.SetInteger("direccio", 1);
        }
         if (name == "Mario" && Input.anyKey)
        {

             if (Input.GetKey(KeyCode.P))
            {
                 m_animator.SetInteger("direccio", 0);
                transform.eulerAngles = new Vector2(0,0);
                rb2d.velocity= new Vector2(speed, rb2d.velocity.y);
            }

            if (Input.GetKey(KeyCode.M))
            {
                m_animator.SetInteger("direccio", 0);
                transform.eulerAngles = new Vector2(0,180);
                rb2d.velocity= new Vector2(-speed, rb2d.velocity.y);
            } 
        }        
        else if (name == "Mario" && !Input.anyKey)
        {
            rb2d.velocity=new Vector2(0.0f, rb2d.velocity.y);
            m_animator.SetInteger("direccio", 1);
        }

        if (name == "PlayerTwo" && Input.anyKey)
        {

             if (Input.GetKey(KeyCode.J))
            {
                 m_animator.SetInteger("direccio2", 0);
                transform.eulerAngles = new Vector2(0,0);
                rb2d.velocity= new Vector2(speed, rb2d.velocity.y);
            }

            if (Input.GetKey(KeyCode.L))
            {
                m_animator.SetInteger("direccio2", 0);
                transform.eulerAngles = new Vector2(0,180);
                rb2d.velocity= new Vector2(-speed, rb2d.velocity.y);
            } 
        }        
        else if (name == "PlayerTwo" && !Input.anyKey)
        {
            rb2d.velocity=new Vector2(0.0f, rb2d.velocity.y);
            m_animator.SetInteger("direccio2", 1);
        }


        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                  timers.text = timeRemaining.ToString("f0");
                  timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
         
    }
}
