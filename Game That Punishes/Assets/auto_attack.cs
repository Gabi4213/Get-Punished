using UnityEngine;

public class auto_attack : MonoBehaviour
{
    public GameObject m_projectile_prefab;
    public float m_attack_rate = 1.5f;
    public Transform m_fire_point;
    private float m_timer;

    private void Update()
    {
        m_timer += Time.deltaTime;

        if(m_timer > m_attack_rate)
        {
            auto_shoot();
            m_timer = 0.0f;
        }
    }

    void auto_shoot()
    {
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shoot_direction = (mouse_pos - transform.position).normalized;

        GameObject projectile = Instantiate(m_projectile_prefab, m_fire_point.position, Quaternion.identity);
        projectile.GetComponent<projectile>().initalize(shoot_direction);
    }
}