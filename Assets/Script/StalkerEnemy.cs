using UnityEngine;
using UnityEngine.AI;

public class StalkerEnemy : MonoBehaviour
{
    public NavMeshAgent miGo;
    public GameObject finalDestination;
    public Transform playerFound;
    public float detection;
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (agent == null || animator == null)
        {
            Debug.LogError("Faltan los componentes NavMeshAgent o Animator.");
            enabled = false;
        }

        playerFound = FindAnyObjectByType<Player>().transform;
    }

    public void Update()
    {
        miGo.destination = finalDestination.transform.position;
        Vector3 worldVelocity = agent.velocity;
        float speed = worldVelocity.magnitude;
        animator.SetFloat("Speed", speed);

        float playerDistance = Vector3.Distance(transform.position, playerFound.position);
        if (playerDistance < detection)
        {
            miGo.destination = playerFound.position;
        }
        else if (playerDistance > detection + 3)
        {
            miGo.destination = finalDestination.transform.position;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(miGo.transform.position, detection);
    }
}
