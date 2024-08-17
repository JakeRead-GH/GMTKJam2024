using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public AudioSource sliderSound;

    private Button upButton;
    private Button downButton;

    public float MIN_PITCH = 0.8f;
    public float MAX_PITCH = 1.2f;


    // Start is called before the first frame update
    void Start()
    {
        upButton = slider.transform.Find("UpButton")?.GetComponent<Button>();
        downButton = slider.transform.Find("DownButton")?.GetComponent<Button>();

        slider.enabled = false;

        upButton.onClick.AddListener(IncreaseSliderValue);
        downButton.onClick.AddListener(DecreaseSliderValue);

        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void IncreaseSliderValue()
    {
        slider.value++;
    }

    void DecreaseSliderValue()
    {
        slider.value--;
    }

    void OnSliderValueChanged(float newValue)
    {
        Debug.Log(newValue);
        PlaySound((int)newValue);
    }

    void PlaySound(int sliderValue)
    {
        UpdatePitch(sliderValue);
        sliderSound.Play();
    }

    void UpdatePitch(int sliderValue)
    {
        float normalizedValue = (float)(sliderValue - slider.minValue) / (slider.maxValue - slider.minValue);
        sliderSound.pitch = Mathf.Lerp(MIN_PITCH, MAX_PITCH, normalizedValue);
    }
}
