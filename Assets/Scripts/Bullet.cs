using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 4f;

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
}
