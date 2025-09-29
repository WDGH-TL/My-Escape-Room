using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class StalkerEnemy : MonoBehaviour
{
    public NavMeshAgent miGo;
    public GameObject finalDestination;
    public Transform playerFound;
    public float detection;
    public float walkingSpeed = 5.5f;
    public float runningSpeed = 9.0f;
    public Transform[] patrolAreas;
    public float finishedPatrol;
    private int patrols;
    private NavMeshAgent agent;
    private Animator animator;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (agent == null || animator == null)
        {
            enabled = false;
        }

        playerFound = FindAnyObjectByType<Player>().transform;
        agent.speed = walkingSpeed;
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

            if (miGo.speed != runningSpeed)
            {
                miGo.speed = runningSpeed;
            }
        }
        else if (playerDistance > detection + 3)
        {
            miGo.destination = finalDestination.transform.position;

            if (miGo.speed != walkingSpeed)
            {
                miGo.speed = walkingSpeed;
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(miGo.transform.position, detection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("YouLoose");
        }
    }
}
