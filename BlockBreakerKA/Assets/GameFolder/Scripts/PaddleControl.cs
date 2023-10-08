using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    [SerializeField]
    float hareketGucu = 50;

    float colliderEnYarim;

    BallControl oyundakiTop;

    [SerializeField]
    bool otomatikOynama = false;

    // Start is called before the first frame update
    void Start()
    {
        GetHalfSpritePaddle();
        oyundakiTop = FindObjectOfType<BallControl>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (otomatikOynama)
        {
            MoveOtomatic();
        }
        else
        {

            MovePaddleMouse();
        }
        StayOnScreen();
    }

    void MovePaddleKeyboard()
    {
        Vector3 position = transform.position;
        float yatayInput = Input.GetAxis("Horizontal");
        if (yatayInput != 0)
        {
            position.x += yatayInput * hareketGucu * Time.deltaTime;
        }
        transform.position = position;
    }

    void MovePaddleMouse()
    {
        Vector3 mPosition = Input.mousePosition;
        mPosition.z = -Camera.main.transform.position.z;
        mPosition = Camera.main.ScreenToWorldPoint(mPosition);
        mPosition.y = transform.position.y;
        transform.position = mPosition;
    }
    void MoveOtomatic()
    {
        Vector3 topPosition = oyundakiTop.transform.position;
        topPosition.y = transform.position.y;
        transform.position = topPosition;
    }
    void GetHalfSpritePaddle()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        colliderEnYarim = spriteRenderer.bounds.size.x / 2;
    }
    void StayOnScreen()
    {
        //   X=100 Y=80  
        Vector3 position = transform.position;
        //    X Ekseni için (YATAY)   
        //     4.5              5               -0.5
        /*if (position.x - colliderEnYarim < ScreenCalc.instance.SolNokta)
        {
            //     ?                 0                     5     
            position.x = ScreenCalc.instance.SolNokta + colliderEnYarim;
            //          95.5              5               100.5     
        }
        else if (position.x + colliderEnYarim > ScreenCalc.instance.SagNokta)
        {
            //     ?                 100                     5     
            position.x = ScreenCalc.instance.SagNokta - colliderEnYarim;
        }
        */
        position.x = Mathf.Clamp(position.x, ScreenCalc.instance.SolNokta + colliderEnYarim, ScreenCalc.instance.SagNokta - colliderEnYarim);
        

        transform.position = position;
    }
}
