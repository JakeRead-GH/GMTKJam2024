using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchMenuView : MonoBehaviour
{
    public Button button;
    public GameObject currentMenu;
    public GameObject targetMenu;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() => SwitchView());
    }

    void SwitchView()
    {
        currentMenu.SetActive(false);
        targetMenu.SetActive(true);
    }
}
