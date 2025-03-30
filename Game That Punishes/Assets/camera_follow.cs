using System.Collections;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public static camera_follow m_instance;
    public Transform m_target;
    public float m_delay = 0.3f;
    public Vector3 m_offset;
    private Vector3 m_velocity = Vector3.zero;
    public float m_shake_duration = 0.5f;
    public float m_shake_magnitude = 0.1f;
    private Coroutine m_shake_coroutine;

    void Start()
    {
        if (!m_instance)
        {
            m_instance = this;
        }
    }

    void LateUpdate()
    {
        if (m_target != null)
        {
            Vector3 target_position = m_target.position + m_offset;
            transform.position = Vector3.SmoothDamp(transform.position, target_position, ref m_velocity, m_delay);
        }
    }

    public void ShakeCamera()
    {
        if (m_shake_coroutine != null)
        {
            StopCoroutine(m_shake_coroutine);
        }
        m_shake_coroutine = StartCoroutine(Shake(m_shake_duration, m_shake_magnitude));
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 original_position = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(original_position.x + x, original_position.y + y, original_position.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = original_position;
    }
}
