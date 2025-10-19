using UnityEngine;

public class OneShot : IEnemyBuilder
{
    private Enemy enemyInstance;
    private GameObject modelPrefab;

    public OneShot(GameObject basePrefab, GameObject model)
    {
        enemyInstance = GameObject.Instantiate(basePrefab).GetComponent<Enemy>();
        modelPrefab = model;
    }

    public void SetHealth()
    {
        enemyInstance.SetHealth(1);
    }

    public void SetSpeed()
    {
        enemyInstance.SetSpeed(1.5f);
    }

    public void SetModel()
    {
        enemyInstance.SetModel(modelPrefab);
    }

    public Enemy GetEnemy()
    {
        return enemyInstance;
    }
}