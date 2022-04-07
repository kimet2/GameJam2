using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static Action<string> PlayerCollectsCoin = delegate { };

    private Rigidbody2D rb;
    private float dirX, dirY, moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (name == "PlayerOne")
        {
            //dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
            dirY = Input.GetAxisRaw("Vertical") * moveSpeed;
        }

        if (name == "PlayerTwo" && Input.anyKey)
        {
            if (Input.GetKey(KeyCode.I))
            {
                dirY = moveSpeed;
            }

            if (Input.GetKey(KeyCode.K))
            {
                dirY = -moveSpeed;
            }

            /* if (Input.GetKey(KeyCode.J))
            {
                dirX = - moveSpeed;
            }

            if (Input.GetKey(KeyCode.L))
            {
                dirX = moveSpeed;
            }*/
        }        
        else if (name == "PlayerTwo" && !Input.anyKey)
        {
            //dirX = 0f;
            dirY = 0f;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
        {
            PlayerCollectsCoin(name);
            Destroy(collision.gameObject);

        }
    } 
}
