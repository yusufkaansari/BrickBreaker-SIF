using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlokSayisi : MonoBehaviour
{
    [SerializeField]
    Text blokSayisiText;
    Bloklar bloklar;

    [SerializeField]
    Text hizText;
    BallControl ball;
    // Start is called before the first frame update
    private void Awake()
    {
        bloklar = FindObjectOfType<Bloklar>();
    }
    void Start()
    {
        blokSayisiText.text = "" + bloklar.BlokSayisiVer();

        ball = FindObjectOfType<BallControl>();

    }

    // Update is called once per frame
    void Update()
    {
        blokSayisiText.text = "" + bloklar.BlokSayisiVer();

        hizText.text = "" + ball.BallHiz;

    }
}
