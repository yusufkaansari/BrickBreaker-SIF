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

    // Start is called before the first frame update
    void Start()
    {
        oyunBari = FindObjectOfType<PaddleControl>();
        body = GetComponent<Rigidbody2D>();
        TopOyunBariUstunde();
        ToplaBarArasindakiMesafe = transform.position - oyunBari.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!oyunBasladiMi)
        {
            
            transform.position = oyunBari.transform.position + ToplaBarArasindakiMesafe;
        }
        if (Input.GetMouseButtonDown(0))
        {
            oyunBasladiMi = true;
            body.velocity = new Vector2(3f, 9f);
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
