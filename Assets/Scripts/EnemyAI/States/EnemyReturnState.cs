using UnityEngine;

public class EnemyReturnState : EnemyState
{
    
    public override void EnterState(EnemyAIController enemy)
    {
        base.EnterState(enemy);
    }

    public override void UpdateState()
    {
        
    }

    public override void OnTriggerStay(Collider other)
    {
    }

    public override void ExitState()
    {
        
    }
}
