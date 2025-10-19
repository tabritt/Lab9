using UnityEngine;

public class Enemy : MonoBehaviour
{
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

    public void SetModel(GameObject modelPrefab)
    {
        if (model != null)
            Destroy(model);

        model = Instantiate(modelPrefab, transform);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
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
