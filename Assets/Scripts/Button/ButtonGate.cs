using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonGate : MonoBehaviour
{
    [SerializeField] private Gate gate;

    private GameObject DownButton;

    [SerializeField] private Sprite[] upSprites = new Sprite[5];
    [SerializeField] private Sprite[] downSprites = new Sprite[5];

    private SizeController sc;
    private SpriteRenderer sr;

    private void Start()
    {
        sc = GetComponent<SizeController>();
        sr = GetComponent<SpriteRenderer>();
        sc.sprites = upSprites;
    }


    private void OnTriggerEnter(Collider other)
    {
        sc.sprites = downSprites;

        for (int i = 0; i < upSprites.Length; i++) 
        { 
            if(sr.sprite == upSprites[i])
            {
                sr.sprite = downSprites[i];
                break;
            }
        }

        gate.GateOpen();
    }


    private void OnTriggerExit(Collider other)
    {
        sc.sprites = upSprites;

        for (int i = 0; i < downSprites.Length; i++)
        {
            if (sr.sprite == downSprites[i])
            {
                sr.sprite = upSprites[i];
                break;
            }
        }

        gate.GateClose();
    }
}
