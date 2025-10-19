using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform groundCheck; //Box collider position to check for obstacles
    public float checkDistance = 0.1f; // how far to check for obstacles
    public LayerMask obstacleLayer; // doing it like how we did the enemy AI thing in the other lab

    private Rigidbody2D rb;
    private bool movingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Patrol();

        // Check for wall/obstacle
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, direction, checkDistance, obstacleLayer);

        if (hit.collider != null)
        {
            Flip();
        }
    }

    private void Patrol()
    {
        float direction = movingRight ? 1f : -1f;
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    private void Flip()
    {
        movingRight = !movingRight;

        // Flip model
        Vector3 scale = transform.localScale;
        scale.x *= -1; //Multuply by -1 to flip the model
        transform.localScale = scale;
    }

    private void OnDrawGizmosSelected()
    {
        // flips the gizmo
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Vector3 dir = movingRight ? Vector3.right : Vector3.left;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + dir * checkDistance);
        }
    }
}
