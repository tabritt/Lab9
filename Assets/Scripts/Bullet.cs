using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 4f;
    public int damage = 1;

    private void OnEnable()
    {
        Invoke(nameof(Disable), lifetime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            gameObject.SetActive(false); // Return to pool
        }
    }
}
