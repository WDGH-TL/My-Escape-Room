using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    [Header("IDLE STATE")]
    public float idleTime;
    public float idleTimer;
    public enum ENEMY_STATE
    {
        Idle,
        Walking,
        Running
    }
    public ENEMY_STATE currentState;

    private void Start()
    {
        currentState = ENEMY_STATE.Idle;
    }
}
