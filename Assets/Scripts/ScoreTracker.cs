using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ScoreTracker : MonoBehaviour, ISaveable
{
    private int scoreCount = 0;
    private string savePath;

    private void Start()
    {
        // Save path
        savePath = Path.Combine(Application.persistentDataPath, "score.dat");
        Enemy.onHit += ScoreUpdate;
     
    }


    // Update is called once per frame
    private void ScoreUpdate(int quantity)
    {
        scoreCount += quantity;
        Debug.Log("Score: " + scoreCount);
        // Save whenever score changes
        SaveData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Score", scoreCount);
        PlayerPrefs.Save();
        Debug.Log("Score saved: " + scoreCount);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            scoreCount = PlayerPrefs.GetInt("Score");
            Debug.Log("Score loaded: " + scoreCount);
            Debug.Log("Transform loaded from " + savePath);
        }
        else
        {
            Debug.Log("No saved score found.");
        }
    }
}