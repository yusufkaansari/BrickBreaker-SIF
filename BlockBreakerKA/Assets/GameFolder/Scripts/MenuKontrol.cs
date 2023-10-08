using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuKontrol : MonoBehaviour
{
    [SerializeField]
    Sprite[] muzikIkonlar = default;

    [SerializeField]
    Button muzikButon = default;

    private void Start()
    {
        if (SaveDB.MuzikAcikKayitVarmi() == false)
        {
            SaveDB.MuzikAcDegerAta(1);
        }
        MuzikAyarlariniDenetle();
    }


    public void Muzik()
    {
        if (SaveDB.MuzikAcikDegerOku() == 1)
        {
            SaveDB.MuzikAcDegerAta(0);
            MuzikKontrol.instance.MuzikCal(false);
            // muzik kapalý ikonu getirilir
            muzikButon.image.sprite = muzikIkonlar[0];
        }
        else
        {
            SaveDB.MuzikAcDegerAta(1);
            MuzikKontrol.instance.MuzikCal(true);
            // muzik kapalý ikonu getirilir
            muzikButon.image.sprite = muzikIkonlar[1];
        }
    }
    void MuzikAyarlariniDenetle()
    {
        if (SaveDB.MuzikAcikDegerOku() == 1)
        {
            muzikButon.image.sprite = muzikIkonlar[1];
            MuzikKontrol.instance.MuzikCal(true);
        }
        else
        {
            muzikButon.image.sprite = muzikIkonlar[0];
            MuzikKontrol.instance.MuzikCal(false);
        }
    }
}
