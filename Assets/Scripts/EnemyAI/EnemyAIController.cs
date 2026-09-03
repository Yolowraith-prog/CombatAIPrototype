using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    private EnemyState currentState;
    private EnemyPatrolState patrolState = new EnemyPatrolState();
    private EnemySuspicousState suspicousState = new EnemySuspicousState();
    private EnemyInvestigateState investigateState = new EnemyInvestigateState();
    private EnemyChaseState chaseState = new EnemyChaseState();
    private EnemyAttackState attackState = new EnemyAttackState();
    private EnemySearchState searchState = new EnemySearchState();
    private EnemyReturnState returnState = new EnemyReturnState();

    public GameObject player;
    public LayerMask playerBlockingLayer;

    public EnemyPerception perception;
    [Header("Patrol Points / If enmpty won't move")]
    public GameObject[] patrolPoints;

    public NavMeshAgent m_navMeshAgent;

    [Header("Enemy Rules")]
    public float waitTime = 5f;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        perception = GetComponent<EnemyPerception>();
        m_navMeshAgent = GetComponent<NavMeshAgent>();

        currentState = patrolState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        //Debug.Log("Current State: " + currentState.GetType().Name);
        currentState?.UpdateState(); // null check for update
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState == newState) return;

        currentState?.ExitState(); // null check
        currentState = newState;
        currentState.EnterState(this);
    }

    private void OnTriggerStay(Collider other)
    {
        currentState?.OnTriggerStay(other); // Calls the ontriggerstay here since monobehaviour 
    }
    public void ChangeToPatrol()
    {
        if (currentState == patrolState) return;

        ChangeState(patrolState);
    }

    public void ChangeToSuspicous()
    {
        if (currentState == suspicousState) return;

        ChangeState(suspicousState);
    }

    public void ChangeToInvestigate()
    {
        if (currentState == investigateState) return;

        ChangeState(investigateState);
    }

    public void ChangeToChase()
    {
        if (currentState == chaseState) return;

        ChangeState(chaseState);
    }

    public void ChangeToAttack()
    {
        if (currentState == attackState) return;

        ChangeState(attackState);
    }

    public void ChangeToSearch()
    {
        if (currentState == searchState) return;

        ChangeState(searchState);
    }

    public void ChangeToReturn()
    {
        if (currentState == returnState) return;

        ChangeState(returnState);
    }
}
