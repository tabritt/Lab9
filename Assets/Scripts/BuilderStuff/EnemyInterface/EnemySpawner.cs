using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyBasePrefab;

    public GameObject oneShotPrefab;
    public GameObject threeShotPrefab;

    public float spawnInterval = 3f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRandomEnemy();
            timer = 0f;
        }
    }
    void Start()
    {
        // One-Shot Enemy
        var oneShotBuilder = new OneShot(enemyBasePrefab, oneShotPrefab);
        var director = new EnemyBuilder(oneShotBuilder);
        var oneShotEnemy = director.Construct();
        oneShotEnemy.transform.position = new Vector3(0, 0, 0);

        // Three-Shot Enemy
        var threeShotBuilder = new ThreeShotEnemyBuilder(enemyBasePrefab, threeShotPrefab);
        director = new EnemyBuilder(threeShotBuilder);
        var threeShotEnemy = director.Construct();
        threeShotEnemy.transform.position = new Vector3(2, 0, 0);


    }
    void SpawnRandomEnemy()
    {
        int type = Random.Range(0, 3); // 0, 1, or 2
        IEnemyBuilder builder = null;

        switch (type)
        {
            case 0:
                builder = new OneShot(enemyBasePrefab, oneShotPrefab);
                break;
            case 1:
                builder = new ThreeShotEnemyBuilder(enemyBasePrefab, threeShotPrefab);
                break;
        
        }

        var director = new EnemyBuilder(builder);
        var enemy = director.Construct();

        // Random spawn position
        float x = Random.Range(-6f, 6f);
        float y = Random.Range(-3f, 3f);
        enemy.transform.position = new Vector3(x, y, 0f);
    }
}
