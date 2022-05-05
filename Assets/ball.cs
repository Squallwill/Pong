using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    public float speed = 20;
    public Text scorerightText;
    public Text scoreleftText;
    public int scoreRight;
    public int scoreLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        // velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
  
    public float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    { 
        return (ballPos.y - racketPos.y) / racketHeight;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
          // Hit the left Racket?
        if (col.gameObject.name == "RacketLeft")
         {
             // Calculate hit Factor
             float y = hitFactor(transform.position,col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

               // Set Velocity with dir * speed
           GetComponent<Rigidbody2D>().velocity = dir * speed;

            GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
        }

        if (col.gameObject.name == "RacketRight")
          {
           // Calculate hit Factor
            float y = hitFactor(transform.position,col.transform.position,col.collider.bounds.size.y);

                // Calculate direction, make length=1 via .normalized
                Vector2 dir = new Vector2(-1, y).normalized;

                // Set Velocity with dir * speed
                GetComponent<Rigidbody2D>().velocity = dir * speed;

            GetComponent<SpriteRenderer>().color = new Color(0.085f, 1f, 0.255f);
        }
        if (col.gameObject.name == "WALLRIGHT")
        {
            scoreLeft ++;
   
            scoreleftText.text = scoreLeft.ToString();

        }
        if (col.gameObject.name == "WALLLEFT")
        {
            scoreRight ++;
            scorerightText.text = scoreRight.ToString();
        }

    }
}
