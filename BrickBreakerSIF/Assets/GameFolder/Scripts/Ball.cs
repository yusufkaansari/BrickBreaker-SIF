using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    bool inPlay;

    [SerializeField] 
    Transform ballOnPaddle;

    [SerializeField]
    float speed;

    [SerializeField]
    Transform explosion;

    [SerializeField]
    GameManager gm;

    [SerializeField]
    Transform powerup;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlay)
        {
            transform.position = ballOnPaddle.position;
        }
        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bottom"))
        {
            gm.UpdateLives(-1);
            if (gm.GetLives() > 0)
            {
                SetInPlay();                
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("brick"))
        {
            Brick brickScript = collision.gameObject.GetComponent<Brick>();
            if (brickScript.hitsToBreak > 1)
            {
                brickScript.BreakBrick();
            }
            else
            {
                int randChance = Random.Range(1, 101);
                if (randChance < 25)
                {
                    Instantiate(powerup, collision.transform.position, collision.transform.rotation);
                }

                Transform smokepuff = Instantiate(explosion, collision.transform.position, Quaternion.identity);
                var main = smokepuff.GetComponent<ParticleSystem>().main;
                main.startColor = new ParticleSystem.MinMaxGradient(Color.gray, collision.gameObject.GetComponent<SpriteRenderer>().color);

                gm.UpdateScore(brickScript.points);
                gm.UpdateNumberOfBricks();
                Destroy(collision.gameObject);
                Destroy(smokepuff.gameObject, 1f);
            }

        }
    }
    public void SetInPlay()
    {
        //Debug.Log("Ball hit the bottom of the screen");
        // Ball nesnesi hareketsizlestirilir:
        rb.velocity = Vector2.zero;
        // inPlay false yapilarak, topun paddle e geri donmesi saglanir
        // boylece top un caný 1 azalmis olunur
        inPlay = false;
    }

}
