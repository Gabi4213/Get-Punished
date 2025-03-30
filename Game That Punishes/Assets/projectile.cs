using UnityEngine;

public class projectile : MonoBehaviour
{
    public float m_speed = 10.0f;
    public float m_lifetime = 2.0f;
    private Vector2 m_direction;

    public void initalize(Vector2 direction)
    {
        m_direction = direction.normalized;
        Destroy(gameObject, m_lifetime);
    }

    private void Update()
    {
        transform.position += (Vector3)(m_direction * m_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}