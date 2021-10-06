using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private GameObject startButton;
    private GameObject exitButton;
    void Start()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach(GameObject go in allObjects)
        {
            switch (go.name)
            {
                case "PlayButton":
                    startButton = go;
                    break;
                case "ExitButton":
                    exitButton = go;
                    break;

            }
        }

        startButton.GetComponent<Button>().onClick.AddListener(StartButtonClick);
        exitButton.GetComponent<Button>().onClick.AddListener(ExitButtonClick);
    }

    private void StartButtonClick()
    {
        SceneManager.LoadScene("world");
    }

    private void ExitButtonClick()
    {
        Application.Quit();


        //quit aplication on editor mode;
        UnityEditor.EditorApplication.isPlaying = false;
    }


}
