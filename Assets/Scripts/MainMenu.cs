using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;

    public InputField nameInputField;


    public void Start()
    {
        LoadName();
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    [System.Serializable]
    class SaveData
    {
        public InputField nameInputField;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.nameInputField = nameInputField;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameInputField = data.nameInputField;
        }

    }





    public void NewStart()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
        Debug.Log("Application Closed");
    }


}
