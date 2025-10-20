using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public delegate void ScoreUpdate(int quantity);
    ScoreUpdate scoreUpdate;
    private int scoreCount = 0;

    private void Start()
    {
        scoreUpdate = ScoreUpdateMethod;
    }

    // Update is called once per frame
    internal void ScoreUpdateMethod(int quantity)
    {
        scoreCount += quantity;
        Debug.Log("Count: " + scoreCount);
    }
}
