using UnityEngine;

    [System.Serializable]
    public class EnemySaveData
    {
        public int health;
        public float speed;
        public Vector3 position;

        public EnemySaveData(Enemy enemy)
        {
            health = enemy.health;
            speed = enemy.speed;
            position = enemy.transform.position;
        }
   
}