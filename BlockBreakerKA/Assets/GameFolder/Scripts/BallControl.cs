using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    PaddleControl oyunBari;
    bool oyunBasladiMi;
    Vector3 ToplaBarArasindakiMesafe;
    float colliderBoyYarim;
    Rigidbody2D body;
    SahneKontrol sahneKontrol;

    float _ballHiz;
    public float BallHiz { get => _ballHiz; }

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        oyunBari = FindObjectOfType<PaddleControl>();
        body = GetComponent<Rigidbody2D>();
        TopOyunBariUstunde();
        ToplaBarArasindakiMesafe = transform.position - oyunBari.transform.position;
        sahneKontrol = FindObjectOfType<SahneKontrol>();

        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!oyunBasladiMi)
        {            
            transform.position = oyunBari.transform.position + ToplaBarArasindakiMesafe;
            if (Input.GetMouseButtonDown(0))
            {
                oyunBasladiMi = true;
                body.AddForce(new Vector2(2f, 8f),ForceMode2D.Impulse);
            }
        } else
        {
            _ballHiz = body.velocity.magnitude;
            if (Bloklar.blockSayisi <= 0)
            {
                sahneKontrol.SonrakiSahne();
            }
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 ufakSapma = new Vector2(Random.Range(0f, 0.3f), Random.Range(0f, 0.3f));
        if (oyunBasladiMi && !collision.gameObject.CompareTag("Breakable"))
        {
            audioSource.Play();
            body.velocity += ufakSapma;
        }
    }

    void GetHalfSpritePaddle()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRendererOyunBari = oyunBari.GetComponent<SpriteRenderer>();
        colliderBoyYarim = (spriteRenderer.bounds.size.y / 2) + spriteRendererOyunBari.bounds.size.y / 2;
    }
    void TopOyunBariUstunde()
    {
        Vector3 tempPositon = oyunBari.transform.position;
        GetHalfSpritePaddle();
        tempPositon.y = oyunBari.transform.position.y + colliderBoyYarim;
        transform.position = tempPositon;
    }
}
