using System;
using System.Collections.Generic;
using UnityEngine;
using static ScoreTracker;

public abstract class Subject : MonoBehaviour
{
    public event ScoreUpdate OnHit;
    private int _quantity = 1;
    public void UpdateScore()
    {
        Debug.Log("I was hit.");
        OnHit?.Invoke(_quantity);
    }
}
