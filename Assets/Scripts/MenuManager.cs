using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string bestName;
    public string playerName;
    public int bestScore;



    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestPlay();
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestName;
    }

    public void SaveBestPlay()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestName = bestName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestPlay()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestName = data.bestName;

        }
    }

}
