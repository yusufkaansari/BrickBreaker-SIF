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

    AudioSource audio;
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

        audio = GetComponent<AudioSource>();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("extraLife"))
        {
            audio.Play();
            gm.UpdateLives(1);
            Destroy(collision.gameObject);
        }
        
    }
}
