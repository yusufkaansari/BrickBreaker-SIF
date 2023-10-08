using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneKontrol : MonoBehaviour
{
    public void SonrakiSahne()
    {
        int mevcutSahneninIndeksi = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(mevcutSahneninIndeksi + 1);
        FindObjectOfType<Bloklar>().BlokSayisiSifirla();
    }

    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void MenuyeDon()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OyunBitti()
    {
        SceneManager.LoadScene("OyunBitti");
    }
}
