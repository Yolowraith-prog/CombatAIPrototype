using Unity.VisualScripting;
using UnityEngine;

public class EnemyPerception : MonoBehaviour
{
    private EnemyAIController m_enemy;
    [SerializeField]
    private bool isPlayerVisible;

    private void Start()
    {
        m_enemy = GetComponent<EnemyAIController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = m_enemy.player.transform.position - m_enemy.transform.position; // Get the direction from the enemy to the player
        Vector3 normalizedDirection = direction.normalized; // Normalize the direction vector
        float distance = direction.magnitude; // Get the distance between the enemy and the player

        RaycastHit hit;
        bool isBlocked = Physics.Raycast(m_enemy.transform.position, normalizedDirection, out hit, distance, m_enemy.playerBlockingLayer);

        if (isBlocked)
        {
            Debug.DrawLine(m_enemy.transform.position, hit.point, Color.red); // Draw a red line to the point of collision
            isPlayerVisible = false;
        }
        else
        {
            Debug.DrawLine(m_enemy.transform.position, m_enemy.player.transform.position, Color.green); // Draw a green line to the player
            isPlayerVisible = true;
        }
    }

    public bool CheckPlayerVisibility()
    {
        return isPlayerVisible;
    }
}

