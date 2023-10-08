using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duvarlar : MonoBehaviour
{
    EdgeCollider2D _edgeCollider;

    private void Awake()
    {
        _edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        _edgeCollider.points = new Vector2[4];
    }
    private void Start()
    {
        ThirdWallScreenCollider();
    }

    void ThirdWallScreenCollider()
    {
        Vector2[] colliderpoints;
        colliderpoints = _edgeCollider.points;
        colliderpoints[0] = new Vector2(ScreenCalc.instance.SolNokta, ScreenCalc.instance.AltNokta);
        colliderpoints[1] = new Vector2(ScreenCalc.instance.SolNokta, ScreenCalc.instance.UstNokta);
        colliderpoints[2] = new Vector2(ScreenCalc.instance.SagNokta, ScreenCalc.instance.UstNokta);
        colliderpoints[3] = new Vector2(ScreenCalc.instance.SagNokta, ScreenCalc.instance.AltNokta);



        _edgeCollider.points = colliderpoints;
    }
}
