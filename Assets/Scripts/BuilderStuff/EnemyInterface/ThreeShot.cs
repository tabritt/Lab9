using UnityEngine;

public class ThreeShotEnemyBuilder : IEnemyBuilder
{
    private Enemy enemyInstance;
    private GameObject modelPrefab;

    public ThreeShotEnemyBuilder(GameObject basePrefab, GameObject model)
    {
        enemyInstance = GameObject.Instantiate(basePrefab).GetComponent<Enemy>();
        modelPrefab = model;
    }

    public void SetHealth()
    {
        enemyInstance.SetHealth(3);
    }

    public void SetSpeed()
    {
        enemyInstance.SetSpeed(2.0f);
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
