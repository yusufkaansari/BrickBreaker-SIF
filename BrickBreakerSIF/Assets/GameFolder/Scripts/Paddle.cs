using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;
    float maxX, height, width, paddleWidth;

    [SerializeField]
    GameManager gm;

    AudioSource audioPaddle;

    Animator animatorPaddle;
    private void Awake()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

    }
    // Start is called before the first frame update
    void Start()
    {
        paddleWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        maxX = width - paddleWidth;

        audioPaddle = GetComponent<AudioSource>();
        animatorPaddle = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -maxX, maxX);
        transform.position = pos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            animatorPaddle.SetBool("BallOnPaddle", true);
            BouncingBall(collision);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        animatorPaddle.SetBool("BallOnPaddle", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("extraLife"))
        {
            audioPaddle.Play();
            gm.UpdateLives(1);
            Destroy(collision.gameObject);
        }
        
    }
    void BouncingBall(Collision2D coll)
    {
        Rigidbody2D ballRb = coll.gameObject.GetComponent<Rigidbody2D>();
        Vector2 hitPoint = coll.contacts[0].point;
        Vector2 paddleCenter = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

        ballRb.velocity = Vector2.zero;

        float difference = paddleCenter.x - hitPoint.x;

        float initialBallSpeed = coll.gameObject.GetComponent<Ball>().speed;

        // Find a way to add stronger force when you have to push to ball back
        // consider removing rigidbody and use manual movement.
        if (hitPoint.x < paddleCenter.x)
        {
            // hit is to the left side
            ballRb.AddForce(new Vector2(-(Mathf.Abs(difference * 200)), initialBallSpeed)); // difference * 143 = ~100 force at maximum
        }
        else
        {
            // hit is to the right side
            ballRb.AddForce(new Vector2(Mathf.Abs(difference * 200), initialBallSpeed)); // difference * 143 = ~100 force at maximum
        }
    }
}
