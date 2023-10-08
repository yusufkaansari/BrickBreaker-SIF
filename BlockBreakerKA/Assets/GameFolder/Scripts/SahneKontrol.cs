using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneKontrol : MonoBehaviour
{
    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Oyun");
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
