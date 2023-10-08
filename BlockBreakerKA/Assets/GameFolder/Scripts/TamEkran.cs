using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamEkran : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        TamEkranYap(spriteRenderer);
    }
    void TamEkranYap(SpriteRenderer spriteRenderer)
    {
        Vector2 tempScale = transform.localScale;
        tempScale.x = ScreenCalc.instance.Genislik * 2 / spriteRenderer.size.x;
        tempScale.y = ScreenCalc.instance.Yukseklik * 2 / spriteRenderer.size.y;
        transform.localScale = tempScale;
    }


}
