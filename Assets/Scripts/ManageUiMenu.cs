using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ManageUiMenu : MonoBehaviour
{
    public string PlayerName;
    public TMP_InputField Input;
    public TextMeshProUGUI BestScore;

    public void Start()
    {
        LoadBestScore();
    }


    public void OnNameEnterd()
    {
        MainManager.Name = Input.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }


    private void LoadBestScore()
    {
        int best = 0;
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            best = JsonUtility.FromJson<ScoreData>(json).score;
        }
        BestScore.text = "Best Score: " + best;
    }

}
