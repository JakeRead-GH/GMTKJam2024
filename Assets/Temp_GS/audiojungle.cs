using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiojungle : MonoBehaviour
{

    public AudioSource clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            clip.pitch = 1;
            clip.Play();
        } 
        else if(Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            clip.pitch = 2;
            clip.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            clip.pitch = 3;
            clip.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            clip.pitch = 4;
            clip.Play();
        }
    }
}
