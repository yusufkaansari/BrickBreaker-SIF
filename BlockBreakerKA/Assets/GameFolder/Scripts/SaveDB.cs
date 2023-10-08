using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveDB
{    
    public static string muzikAcik = "muzikAcik";

    public static void MuzikAcDegerAta(int muzikAcik)
    {
        PlayerPrefs.SetInt(SaveDB.muzikAcik, muzikAcik);
    }
    public static int MuzikAcikDegerOku()
    {
        return PlayerPrefs.GetInt(SaveDB.muzikAcik);
    }
    
    public static bool MuzikAcikKayitVarmi()
    {
        if (PlayerPrefs.HasKey(SaveDB.muzikAcik))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
