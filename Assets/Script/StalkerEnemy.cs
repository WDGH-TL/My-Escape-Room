using UnityEngine;
using UnityEngine.AI;

public class StalkerEnemy : MonoBehaviour
{
    public NavMeshAgent miGo;
    public GameObject finalDestination;
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
    }

    public void Update()
    {
        miGo.destination = finalDestination.transform.position;
        Vector3 worldVelocity = agent.velocity;
        float speed = worldVelocity.magnitude;
        animator.SetFloat("Speed", speed);
    }
}
