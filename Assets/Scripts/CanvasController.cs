using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private List<Slider> sliders = new List<Slider>();

    // Start is called before the first frame update
    private void Awake()
    {
        sliders = GetComponentsInChildren<Slider>().ToList();
    }

    public void ActiveSlider(GameObject gameObject)
    {
        DisableAllSliders();
        gameObject.GetComponent<Slider>().enabled = true;
    }

    private void DisableAllSliders()
    {
        foreach (Slider slider in sliders)
        {
            slider.enabled = false;
        }
    }

}
