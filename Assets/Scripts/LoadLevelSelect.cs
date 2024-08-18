using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelSelect : MonoBehaviour
{
    public Button levelSelectButton;
    public GameObject titleMenu;
    public GameObject levelSelectMenu;

    // Start is called before the first frame update
    void Start()
    {
        levelSelectButton.onClick.AddListener(() => SwitchView());
    }

    void SwitchView()
    {
        titleMenu.SetActive(false);
        levelSelectMenu.SetActive(true);
    }
}
