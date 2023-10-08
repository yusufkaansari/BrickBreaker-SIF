using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField]
    float minX, maxY;
    BallController ball;

    float cameraWith,cameraHeight;

    [SerializeField]
    bool autoPlay;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<BallController>();
        CalcScreenRatio();
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }
    void MoveWithMouse()
    {
        Vector3 PaddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        //sahnede 16 kare olduðu için 16 ile çarpýlýr
        float MousePos = Input.mousePosition.x / Screen.width * cameraWith;
        PaddlePos.x = Mathf.Clamp(MousePos, minX, maxY);
        transform.position = PaddlePos;
    }

    void CalcScreenRatio()
    {
        Camera cam = Camera.main;
        cameraHeight = 2 * cam.orthographicSize;
        cameraWith = cameraHeight * cam.aspect;
    }
    void AutoPlay()
    {
        Vector3 PaddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        //sahnede 16 kare olduðu için 16 ile çarpýlýr
        float BallPos = ball.transform.position.x;
        PaddlePos.x = Mathf.Clamp(BallPos, minX, maxY);
        transform.position = PaddlePos;
    }

}
