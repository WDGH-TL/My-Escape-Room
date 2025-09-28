using UnityEngine;
using UnityEngine.AI;

public class StalkerEnemy : MonoBehaviour
{
    public NavMeshAgent miGo;
    public GameObject finalDestination;

    public void Update()
    {
        miGo.destination = finalDestination.transform.position;
    }
}
