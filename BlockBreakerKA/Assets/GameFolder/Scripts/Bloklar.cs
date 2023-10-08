using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bloklar : MonoBehaviour
{
    public static int blockSayisi;
    [SerializeField]
    int can;
    public int Can { get => can; }
    int vurulmaSayisi;
    public int VurulmaSayisi { get => vurulmaSayisi; }
    [SerializeField]
    Sprite[] blokGorunumleri;
    SpriteRenderer spriteRenderer;

    AudioSource audioSource;

    AudioSource blokyokolma;

    [SerializeField]
    GameObject efekt;
    
    private void Awake()
    {
        if (gameObject.CompareTag("Breakable"))
        {
            blockSayisi++;
        }
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        blokyokolma = FindObjectOfType<ScreenCalc>().GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {        
        vurulmaSayisi = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Breakable"))
        {
            VurulmaKontrolu();
            
        }
        
    }
    public int BlokSayisiVer()
    {
        return blockSayisi;
    }
    public void BlokSayisiSifirla()
    {
        blockSayisi = 0;
    }
    void VurulmaKontrolu()
    {
        vurulmaSayisi++;
        // == yerine >= ile frame hatalari engellenir
        if (vurulmaSayisi >= can)
        {
            blokyokolma.Play();
            GameObject efektimiz = Instantiate(efekt, gameObject.transform.position, Quaternion.identity) as GameObject;
            efektimiz.GetComponent<ParticleSystem>().startColor = spriteRenderer.color;

            Destroy(gameObject);
            blockSayisi--;
        }
        else
        {
            BlokHasarGoruntusuDegistir();
            audioSource.Play();
        }
    }
    public void BlokHasarGoruntusuDegistir()
    {
        spriteRenderer.sprite = blokGorunumleri[vurulmaSayisi - 1];
    }
}
