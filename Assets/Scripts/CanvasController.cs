using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    private List<Slider> sliders;

    private GameObject activeSlider;

    // Camera is used to find the on screen position of the player
    [SerializeField] private Camera levelCamera;

    // Start is called before the first frame update
    private void Awake()
    {
        sliders = GetComponentsInChildren<Slider>(includeInactive: true).ToList();
        activeSlider = null;
    }

    private void Update()
    {
        if (activeSlider != null) 
        {
            Slider daSlider = activeSlider.GetComponent<Clickable>().slider;
            RectTransform sliderPosition = daSlider.GetComponent<RectTransform>();

            Vector3 playerOnScreen = levelCamera.WorldToScreenPoint(activeSlider.transform.position);

            // The position is subtracted by a hard coded offset, feel free to make it more modular for different objects
            sliderPosition.localPosition = playerOnScreen - new Vector3(396.2f, 216.4f, 0);
        }
    }

    public void ActiveSlider(GameObject gameObject)
    {
        DisableAllSliders();

        activeSlider = gameObject;

        gameObject.GetComponent<Clickable>().slider.gameObject.active = true;
    }

    private void DisableAllSliders()
    {
        foreach (Slider slider in sliders)
        {
            slider.gameObject.active = false;
        }
    }

}
