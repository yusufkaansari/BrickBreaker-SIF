using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int points;
    public int hitsToBreak;
    public Sprite [] hitSprite;

    public void BreakBrick()
    {
        if (hitSprite.Length>0)
        {
            //2 vuruslu brick ise 1.catlamasi
            if (hitsToBreak == 2)
            {
                GetComponent<SpriteRenderer>().sprite = hitSprite[0];
                hitsToBreak--;
                // 3 vuruslu brick ise 2.catlamasi
                if (hitSprite.Length==2)
                {
                    GetComponent<SpriteRenderer>().sprite = hitSprite[1];
                    hitsToBreak--;
                }
            //3 vuruslu brick ise 1.catlamasi
            }else if (hitsToBreak == 3)
            {
                GetComponent<SpriteRenderer>().sprite = hitSprite[0];
                hitsToBreak--;
            }
        }
        
    }
}
