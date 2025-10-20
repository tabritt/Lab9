using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class ScoreTracker : MonoBehaviour
{
    private int scoreCount = 0;
    public TMP_Text scoreText;

    private void Start()
    {
        Enemy.onHit += ScoreUpdate;
    }

    private void Update()
    {
        scoreText.text = "Score: " + scoreCount.ToString();
    }

    // Update is called once per frame
    private void ScoreUpdate(int quantity)
    {
        scoreCount += quantity;
        Debug.Log("Current Score: " + scoreCount);
    }
}
