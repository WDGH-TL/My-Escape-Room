using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class StalkerEnemy : MonoBehaviour
{
    public NavMeshAgent miGo;
    public Transform playerFound; // Player aora es el perseguido
    public float detection; // Detecta al player
    public float walkingSpeed = 5.5f; // Caminar Animación
    public float runningSpeed = 9.0f; // Correr Animación
    public Transform[] patrolAreas; // Lista de Areas a patrullar
    public float distanceDestinies; // Distancia del enemigo y el primer Area
    private int patrols; // Contador
    private NavMeshAgent agent; // Animación
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
        distanceDestinies = Vector3.Distance(transform.position, patrolAreas[patrols].position);
        miGo.destination = patrolAreas[patrols].position;
    }

    public void Update()
    {
        Vector3 worldVelocity = agent.velocity;
        float speed = worldVelocity.magnitude;
        animator.SetFloat("Speed", speed);

        float playerDistance = Vector3.Distance(transform.position, playerFound.position);

        if (distanceDestinies < 2)
        {
            //miGo.destination = patrolAreas[patrols].position;
            miGo.destination = patrolAreas[patrols].position;

        }

        if (playerDistance <= detection)
        {
            miGo.destination = playerFound.position;


        }
        else if (playerDistance > detection + 3)
        {

            if (!miGo.pathPending && miGo.remainingDistance < 0.5f)
            {
                patrols = (patrols + 1) % patrolAreas.Length;
                miGo.destination = patrolAreas[patrols].position;


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
