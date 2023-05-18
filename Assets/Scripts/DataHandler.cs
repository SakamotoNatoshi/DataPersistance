using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public static DataHandler Instance;
    public string username;
    public int bestScore;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        LoadUserData();
    }
    
    [System.Serializable]
    class SaveData
    {
        public string username;
        public int bestScore;
    }
    
    public void SaveUserData()
    {
        SaveData data = new SaveData();
        data.username = username;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    
    public void LoadUserData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            username = data.username;
            bestScore = data.bestScore;
            
            Debug.Log("File exists.");
        }
        else
        {
            Debug.Log("File does not exist.");
        }
    }
    
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    private void OnApplicationQuit()
    {
        SaveUserData();
    }
}
