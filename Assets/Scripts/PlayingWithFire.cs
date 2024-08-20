using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingWithFire : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite largeSun;
    public GameObject flames;
    public GameObject boxFlames;
    public GameObject boxes;
    public GameObject reddishHue;

    private bool burned = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!burned && spriteRenderer.sprite == largeSun)
        {
            burned = true;
            LetTheFlamesConsumeAll();
        }
    }

    private void LetTheFlamesConsumeAll()
    {
        flames.SetActive(true);
        boxFlames.SetActive(true);
        reddishHue.SetActive(true);

        Audio_Manager.instance.PlayMetalMusic();

        Invoke("BurnBoxes", 3);
    }

    private void BurnBoxes()
    {
        boxFlames.SetActive(false);
        boxes.SetActive(false);
    }
}
