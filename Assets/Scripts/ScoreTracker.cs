using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    private int scoreCount = 0;

    private void Start()
    {
        Enemy.onHit += ScoreUpdate;
    }

    // Update is called once per frame
    private void ScoreUpdate(int quantity)
    {
        scoreCount += quantity;
        Debug.Log("Score: " + scoreCount);
    }
}
