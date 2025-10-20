using NUnit.Framework;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void ScoreUpdate(int quantity);
    public static event ScoreUpdate onHit;
    private int _quantity = 1;
    public int health;
    public float speed;
    public GameObject model;

    public void SetHealth(int value)
    {
        health = value;
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }
    
    public void UpdateScore()
    {
        onHit?.Invoke(_quantity);
    }

    public void SetModel(GameObject modelPrefab)
    {
        if (model != null)
            Destroy(model);

        model = Instantiate(modelPrefab, transform);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateScore();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
