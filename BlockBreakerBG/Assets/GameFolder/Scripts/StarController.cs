using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField]
    int maxHit;

    int timesHit;


    private void Start()
    {
        timesHit = 0;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0.0f, 10.0f * Time.deltaTime * 20.0f, 0.0f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitTheBlock();
    }

    void HitTheBlock()
    {
        timesHit++;
        if (timesHit >= maxHit)
        {
            Destroy(gameObject);
        }
    }
}
