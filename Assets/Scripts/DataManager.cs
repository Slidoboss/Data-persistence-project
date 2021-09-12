using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public int highScore;
    public string playerName;
    public string hsPlayerName;

    public void Awake()
    {
        if (instance != null) 
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
   /* public string GetName(string name) 
    {
        playerName = name;
        return playerName;
    }*/

    [System.Serializable]
    class SaveData
    {
        public int recordedScore;
        public string recordedName;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData(); //intialization of class where data will be stored.
        data.recordedScore = highScore;
        data.recordedName = playerName;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.recordedScore;
            hsPlayerName = data.recordedName;
        }
    }
}
