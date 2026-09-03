using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    private int currentCheckpoint = 0;
    private float waitTimer = 0;
    public override void EnterState(EnemyAIController enemy)
    {
        base.EnterState(enemy);
    }

    public override void UpdateState()
    {
        m_enemy.m_navMeshAgent.SetDestination(m_enemy.patrolPoints[currentCheckpoint].transform.position); // Move towards the current checkpoint
    }
    public override void OnTriggerStay(Collider other)
    {
        Debug.Log(waitTimer);
        if (other.gameObject == m_enemy.patrolPoints[currentCheckpoint]) // Checks if the enemy has reached the current checkpoint
        {
            waitTimer += Time.deltaTime * 0.5f;
        }

        if (waitTimer >= m_enemy.waitTime && currentCheckpoint < m_enemy.patrolPoints.Length -1) // Go to the next checkpoint after waiting for the specified time
        {
            currentCheckpoint++;
            waitTimer = 0;
        }
        if (waitTimer >= m_enemy.waitTime && currentCheckpoint <= m_enemy.patrolPoints.Length -1) // If the last checkpoint is reached reset to the first checkpoint)
        {
            currentCheckpoint = 0; 
            waitTimer = 0;
        }
    }


    
    public override void ExitState()
    {
        
    }
}
