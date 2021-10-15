using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.IO;
public class SaveGame
{
    public Vector2 playerPos;
}

public class ButtonManager : MonoBehaviour
{
    private GameObject startButton;
    private GameObject exitButton;
    private GameObject resumeButton;
    private GameObject saveButton;
    private GameObject loadButton;
    private GameObject pauseCanvas;
    private GameObject player;

    private string path;

    void Start()
    {
        path = Application.persistentDataPath + "/definitelyNotTheSaveFile.josn";


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
                case "ResumeButton":
                    resumeButton = go;
                    break;
                case "SaveButton":
                    saveButton = go;
                    break;
                case "LoadButton":
                    loadButton = go;
                    break;
                case "PauseCanvas":
                    pauseCanvas = go;
                    break;
            }
        }

        if(startButton)
            startButton.GetComponent<Button>().onClick.AddListener(StartButtonClick);
        if (exitButton)
            exitButton.GetComponent<Button>().onClick.AddListener(ExitButtonClick);
        if (resumeButton)
            resumeButton.GetComponent<Button>().onClick.AddListener(ResumeButtonClick);
        if (saveButton)
            saveButton.GetComponent<Button>().onClick.AddListener(SaveButtonClick);
        if (loadButton)
            loadButton.GetComponent<Button>().onClick.AddListener(LoadButtonClick);
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

    private void ResumeButtonClick()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    private void SaveButtonClick()
    {
        SaveGame temp = new SaveGame();

        player = GameObject.Find("Kletinho(Clone)");

        temp.playerPos = player.transform.position;

        string json = JsonUtility.ToJson(temp);

        File.WriteAllText(path, json);
    }

    private void LoadButtonClick()
    {
        SaveGame loadedData = JsonUtility.FromJson<SaveGame>(File.ReadAllText(path));

        player = GameObject.Find("Kletinho(Clone)");

        player.transform.position = new Vector3(loadedData.playerPos.x, loadedData.playerPos.y, 0.0f);

    }


}
