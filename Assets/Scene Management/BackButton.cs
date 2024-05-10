using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public Button backButton;
    public string sceneName;

    void Start()
    {
        backButton.onClick.AddListener(LoadScene);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
