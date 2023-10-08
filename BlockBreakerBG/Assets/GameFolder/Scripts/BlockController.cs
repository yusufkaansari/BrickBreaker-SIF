using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    int maxHit;

    int timesHit;

    bool isBreakable;
    public static int breakableNumber=0;

    LevelManager levelManager;

    [SerializeField]
    Sprite[] hitSprites;

    [SerializeField]
    GameObject smoke;

    int spriteInfo;

    // Start is called before the first frame update
    void Start()
    {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            //kirilabilir blocklarin sayisini hesaplama
            breakableNumber++;
        }

        levelManager = FindObjectOfType<LevelManager>();
        timesHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable)
        {
            HitTheBlock();
        }
    }
    void HitTheBlock()
    {
        timesHit++;
        maxHit = hitSprites.Length + 1;
        if (timesHit>=maxHit)
        {
            breakableNumber--;
            Destroy(gameObject);
            levelManager.BrickDestroyed();
            PuffSmoke();
            
        }
        else
        {
            LoadSprite();
        }
    }
    void PuffSmoke()
    {
        GameObject smokepuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        var main = smokepuff.GetComponent<ParticleSystem>().main;
        main.startColor = GetComponent<SpriteRenderer>().color;
    }
    void LoadSprite()
    {
        spriteInfo = timesHit - 1;
        if (hitSprites[spriteInfo]!=null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteInfo];
        }
        else
        {
            Debug.LogError("Missing block sprites");
        }

    }
}
