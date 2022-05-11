using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public InputField inputField;
    public static string playerName;
    public Text highScoreText;
    public int highScore;
    public string highScoreName;

    public void Awake()
    {
         highScoreName = PlayerPrefs.GetString("Player Name");
         highScore = PlayerPrefs.GetInt("High Score");
         highScoreText.text = "Best Score: " + highScoreName + ": " + highScore;
    }
    public void StartGame()
    {    
        SceneManager.LoadScene(1);
    }
    public void Start()
    {        
        inputField.onEndEdit.AddListener(delegate { inputValue(inputField); });
    }

    public void inputValue(InputField userInput)
    {
        playerName = userInput.text;
        Debug.Log(userInput.text);
    }

    public void Exit()
    {
        PlayerPrefs.SetString("Player Name", highScoreName);
        PlayerPrefs.SetInt("High Score", highScore);
        PlayerPrefs.Save();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }
}
