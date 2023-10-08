using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    PaddleController paddle;
    bool hasStarted = false;
    Vector3 paddleToBallVector;
    Rigidbody2D body;

    AudioSource hitSound;

    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        paddle = GameObject.FindObjectOfType<PaddleController>();
        paddleToBallVector = this.transform.position - paddle.transform.position;

        body = GetComponent<Rigidbody2D>();
        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            transform.position = paddleToBallVector + paddle.transform.position;
        }
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            body.velocity = new Vector2(speed, speed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 ufakSapma = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted)
        {
            hitSound.Play();
            body.velocity += ufakSapma;
        }
    }
}
