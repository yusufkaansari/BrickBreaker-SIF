using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloklar : MonoBehaviour
{
    [SerializeField]
    int can;

    int vurulmaSayisi;
    // Start is called before the first frame update
    void Start()
    {
        vurulmaSayisi = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        vurulmaSayisi++;
        if (vurulmaSayisi == can)
        {
            Destroy(gameObject);
        }
    }
}
