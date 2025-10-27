using NUnit.Framework;
using UnityEngine;
using System.IO;
public class Enemy : MonoBehaviour, ISaveable
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
    public void SaveData()
    {
        EnemySaveData data = new EnemySaveData(this);
        string json = JsonUtility.ToJson(data, true);
        string path = Application.persistentDataPath + $"/enemy_{gameObject.GetInstanceID()}.json";
        File.WriteAllText(path, json);
        
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + $"/enemy_{gameObject.GetInstanceID()}.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            EnemySaveData data = JsonUtility.FromJson<EnemySaveData>(json);
            health = data.health;
            speed = data.speed;
            transform.position = data.position;
            
        }
      
    }
    private void OnEnable()
    {
        EnemyManager.Instance?.RegisterEnemy(this);
    }

    private void OnDisable()
    {
        EnemyManager.Instance?.UnregisterEnemy(this);
    }

}
