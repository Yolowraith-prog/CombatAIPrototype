using UnityEngine;

public class EnemyChaseState : EnemyState
{
    private EnemyAIController m_enemy;
    public override void EnterState(EnemyAIController enemy)
    {
        m_enemy = enemy;
    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {
        
    }
}
