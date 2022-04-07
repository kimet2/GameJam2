using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float starWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;

    // Start is called before the first frame update
    void Start()
    {
        //Es el start del temps 

        waitTime = starWaitTime;

        // El spot que fem tindra un rang random que li asignarem a traves del movespots
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        // fem una posicio amb eix x y  x velocitat  temps
        speed += 0.1f * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        // Distancia x transform position amb una separacio de 0.2 float seria como cuando estes a 0.2 cm vuelva al siguiente lugar
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = starWaitTime;

            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}

//  hem de crear un empty y en el simbol  del cubo escollir el rombe  , fe 2 protocols  per exemple  que seran empyts Amb el nom moveSpots  y si mireu el script asignat al enemy surt
//Move Spots doneuli click i alli arrastreu els emptys