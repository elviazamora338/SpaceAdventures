using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 10f; // Adjust this speed as needed
    private Vector3 direction;

    // Method to set the direction of the projectile
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile in the set direction
        transform.position += direction * speed * Time.deltaTime;

        // You might also want to add some code to destroy the projectile
        // when it's out of the screen or hits something.
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Projectile collided with: " + collision.gameObject.name);
        
        Destroy(gameObject);
    }
}
