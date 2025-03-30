using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float m_move_speed = 5.0f;
    private Rigidbody2D m_rigidbody;
    private Vector2 m_movement;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //movement
        m_movement.x = Input.GetAxisRaw("Horizontal");
        m_movement.y = Input.GetAxisRaw("Vertical");
        m_movement = m_movement.normalized;

        //look direction
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouse_pos - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void FixedUpdate()
    {
        m_rigidbody.linearVelocity = m_movement * m_move_speed; 
    }
}