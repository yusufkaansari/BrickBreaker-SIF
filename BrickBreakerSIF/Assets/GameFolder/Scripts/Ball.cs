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
            Debug.Log("Ball hit the bottom of the screen");
            // Ball nesnesi hareketsizlestirilir:
            rb.velocity = Vector2.zero;
            // inPlay false yapilarak, topun paddle e geri donmesi saglanir
            // boylece top un caný 1 azalmis olunur
            inPlay = false;
        }
    }
}
