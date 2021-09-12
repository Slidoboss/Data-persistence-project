using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIController : MonoBehaviour
{
    public InputField  userInput;
    public string playerName;
    public TextMeshProUGUI menuScore;

    void Start()
    {
       menuScore.text = "HighScore: " + DataManager.instance.hsPlayerName + " : " + DataManager.instance.highScore;//Dislpays Highscore and player name in main menu
       userInput.SetTextWithoutNotify(DataManager.instance.hsPlayerName);// Displays text on input field on start
    }

    public void StartGame()
    {
       
        if (userInput.text != "")
        {
            //  DataManager.instance.GetName(userInput.text);
            DataManager.instance.playerName = userInput.text;
        }
        else
        {
            //  DataManager.instance.GetName("Noname");
            DataManager.instance.playerName = "NoName";
        }
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
