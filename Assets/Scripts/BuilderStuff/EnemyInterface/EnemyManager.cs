using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    private List<ISaveable> enemies = new List<ISaveable>();
    private string savePath;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        savePath = Application.persistentDataPath + "/enemies.json";
    }

    // if enemy contain Enemy Script
    public void RegisterEnemy(ISaveable enemy)
    {
        if (!enemies.Contains(enemy))
            enemies.Add(enemy);
    }

    // if die ermove script from list
    public void UnregisterEnemy(ISaveable enemy)
    {
        if (enemies.Contains(enemy))
            enemies.Remove(enemy);
    }

    
    public void SaveAllEnemies()
    {
        foreach (var enemy in enemies)
            enemy.SaveData();

    }


    public void LoadAllEnemies()
    {
        foreach (var enemy in enemies)
            enemy.LoadData();
    }
}
