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
        Debug.Log("sdfdsfdsfdsff");
        sc.sprites = upSprites;

        for (int i = 0; i < upSprites.Length; i++) 
        { 
            if(sr.sprite == upSprites[i])
            {
                sr.sprite = downSprites[i];
                break;
            }
        }

        //if(sr.sprite == upSprites[0])
        //{

        //} 
        //else if(sr.sprite == upSprites[1])
        //{

        //}
        //else if (sr.sprite == upSprites[2])
        //{

        //}
        //else if (sr.sprite == upSprites[3])
        //{

        //}
        //else if (sr.sprite == upSprites[4])
        //{

        //}

        gate.GateOpen();
    }


    private void OnTriggerExit(Collider other)
    {
        sc.sprites = downSprites;

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
