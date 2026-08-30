using UnityEngine;

public abstract class EnemyState
{
    protected EnemyAIController m_enemy;
    public virtual void EnterState(EnemyAIController enemy)
    {
        m_enemy = enemy;
    }
        
    public abstract void UpdateState();
    public abstract void ExitState();

}
