using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class MenuUIHandler : MonoBehaviour
{
    //handler of the main menu scene
    [SerializeField] Text PlayerNameInput;

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void SetPlayerName()
    {
        PlayerDataHandle.instance.PlayerName = PlayerNameInput.text;
    }

    public void ExitGame()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
        Debug.Log("Application Closed");
    }
}
