using UnityEngine;
using UnityEngine.AI;

public class EnemyStates : MonoBehaviour
{
    private NavMeshAgent miGo;

    [Header("IDLE STATE")]
    public float idleTime;
    public float idleTimer;

    public Transform[] patrolAreas;
    public enum ENEMY_STATE
    {
        Idle,
        Walking,
        Running
    }
    public ENEMY_STATE currentState;

    private void Awake()
    {
        miGo = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        currentState = ENEMY_STATE.Idle;
    }

    private void Update()
    {
        if(currentState == ENEMY_STATE.Idle)
        {
            idleTime += Time.deltaTime;
            if(idleTimer > idleTime)
            {
                idleTimer = 0;
                ChangeEnemyState(ENEMY_STATE.Walking);
            }
        }
        else if(currentState  == ENEMY_STATE.Walking)
        {
            if(miGo.remainingDistance <= miGo.stoppingDistance)
            {
                ChangeEnemyState(ENEMY_STATE.Idle);
            }
        }
    }

    private void ChangeEnemyState(ENEMY_STATE newState)
    {
        currentState = newState;
        if(currentState == ENEMY_STATE.Walking)
        {
            miGo.SetDestination(patrolAreas[Random.Range(0, patrolAreas.Length)].position);
        }

        if(!miGo.pathPending && miGo.remainingDistance <= miGo.stoppingDistance)
        {
            ChangeEnemyState(ENEMY_STATE.Idle);
        }
    }
}
