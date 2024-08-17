using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    [SerializeField] 
    public Light dl;

    private Color colorBase;

    // Start is called before the first frame update
    void Start()
    {
        colorBase = dl.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.localScale += new Vector3(3f, 3f, 3f);

            dl.color = Color.Lerp(dl.color, Color.red, 0.2f);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localScale += new Vector3(-3f, -3f, -3f);
            dl.color = Color.Lerp(dl.color, colorBase, 0.2f);
        }
    }
}
