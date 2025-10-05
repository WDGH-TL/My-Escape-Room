using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class StalkerEnemy : MonoBehaviour
{
    public NavMeshAgent miGo;
    public Transform playerFound; // Player ahora es el perseguido
    public float detection; // Detecta al player
    public float walkingSpeed = 5.5f; // Caminar Animación
    public float runningSpeed = 9.0f; // Correr Animación
    public Transform[] patrolAreas; // Lista de Areas a patrullar
    public float distanceDestinies; // Distancia del enemigo y el primer Area
    private int patrols; // Contador
    private Animator animator;
    public AudioSource playerIsFound;
    public float idleTime = 2.0f;
    public float idleTimer;

    AudioSource itemDropHeard;
    Vector3 itemPosition;
    bool findSoundSorce;

    public enum ENEMY_STATE
    {
        Idle,
        Walking,
        Running
    }
    public ENEMY_STATE currentState;

    void Start()
    {

        currentState = ENEMY_STATE.Idle;
        playerIsFound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        if (miGo == null || animator == null)
        {
            enabled = false;
        }

        playerFound = FindAnyObjectByType<Player>().transform;
        miGo.speed = walkingSpeed;
        distanceDestinies = Vector3.Distance(transform.position, patrolAreas[patrols].position);
        miGo.destination = patrolAreas[patrols].position;
        WalkingState();
    }


    public void Update()
    {
        float speed = miGo.velocity.magnitude;
        animator.SetFloat("Speed", speed);
        float playerDistance = Vector3.Distance(transform.position, playerFound.position);
        switch (currentState)
        {
            case ENEMY_STATE.Idle:
                if(playerDistance <= detection)
                {
                    RunningState();
                }
                idleTimer -= Time.deltaTime;
                if (idleTimer <= 0)
                {
                    patrols = (patrols + 1) % patrolAreas.Length;
                    WalkingState();
                }
                break;

            case ENEMY_STATE.Walking:
                if(playerDistance <= detection)
                {
                    RunningState();
                }
                if (!miGo.pathPending && miGo.remainingDistance < 0.5f)
                {
                    IdleState();
                }
                break;

            case ENEMY_STATE.Running:
                if(playerDistance >= detection +3)
                {
                    WalkingState();
                }
                miGo.destination = playerFound.position;
                break;
        }
        if (findSoundSorce == true)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, itemPosition, 9 * Time.deltaTime);
        }
    }
    void IdleState()
    {
        currentState = ENEMY_STATE.Idle;
        idleTimer = idleTime;
        miGo.isStopped = true;
    }

    void WalkingState()
    {
        currentState = ENEMY_STATE.Walking;
        miGo.isStopped = false;
        miGo.speed = walkingSpeed;
        miGo.destination = patrolAreas[patrols].position;
        if (playerIsFound.isPlaying)
        {
            playerIsFound.Stop();
        }
    }

    void RunningState()
    {
        currentState = ENEMY_STATE.Running;
        miGo.isStopped = false;
        miGo.speed = runningSpeed;
        miGo.destination = patrolAreas[patrols].position;
        if (!playerIsFound.isPlaying)
        {
            playerIsFound.Play();
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
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<AudioSource>() != null)
        {
            itemDropHeard = other.GetComponent<AudioSource>();
            if (itemDropHeard.isPlaying)
            {
                itemDropHeard = other.GetComponent<AudioSource>();
                itemPosition = itemDropHeard.transform.position;
            }
        }
    }

}
