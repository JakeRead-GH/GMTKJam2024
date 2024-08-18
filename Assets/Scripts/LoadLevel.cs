using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public Button button;
    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() => SwitchScene(levelName));
    }

    void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }   
}
