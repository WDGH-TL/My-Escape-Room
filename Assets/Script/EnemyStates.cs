using UnityEngine;

public class EnemyStates : MonoBehaviour
{
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
