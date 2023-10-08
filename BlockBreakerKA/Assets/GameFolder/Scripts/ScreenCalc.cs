using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCalc : MonoBehaviour
{
    public static ScreenCalc instance;

    float _yukseklik;
    float _genislik;

    float _solNokta;
    float _sagNokta;
    float _ustNokta;
    float _altNokta;

    public float SolNokta { get => _solNokta; }
    public float SagNokta { get => _sagNokta; }
    public float UstNokta { get => _ustNokta; }
    public float AltNokta { get => _altNokta; }

    public float Yukseklik { get => _yukseklik; }
    public float Genislik { get => _genislik; }
    private void Awake()
    {
        Singleton();
        CalcPoints();

    }
    void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void CalcPoints()
    {
        _yukseklik = Camera.main.orthographicSize;
        _genislik = _yukseklik * Camera.main.aspect;

        float ekranZekseni = -Camera.main.transform.position.z;
        Vector3 solAltKose = new Vector3(0, 0, ekranZekseni);
        Vector3 sagUstKose = new Vector3(Screen.width, Screen.height, ekranZekseni);
        Vector3 solAltKoseOyunDunyasi = Camera.main.ScreenToWorldPoint(solAltKose);
        Vector3 sagUstKoseOyunDunyasi = Camera.main.ScreenToWorldPoint(sagUstKose);
        _solNokta = solAltKoseOyunDunyasi.x;
        _sagNokta = sagUstKoseOyunDunyasi.x;
        _ustNokta = sagUstKoseOyunDunyasi.y;
        _altNokta = solAltKoseOyunDunyasi.y;
    }
}
