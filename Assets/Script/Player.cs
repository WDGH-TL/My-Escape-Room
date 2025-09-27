using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{
    public Rigidbody myPlayer;
    public float velocidad = 5f;
    public float runVelocidad = 10f;
    public bool isRunning = false;
    public float currentSpeed;

    public float movementX;
    public float movementY;


    Vector3 velocity;
    public Transform haySuelo;
    public float radioDeSueloListener = 0.3f;
    public LayerMask suelo;
    public float alturaSalto;
    public bool enElSuelo;

    public Vector2 sensibilidadMouse;
    public Transform camara;

    void Start()
    {
        myPlayer = GetComponent<Rigidbody>();
    }
    void Update()
    {
        enElSuelo = Physics.CheckSphere(haySuelo.position, radioDeSueloListener, suelo);
        if (haySuelo && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        movement();
        mouseLook();

    }
    void movement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        Vector3 movimiento = Vector3.zero;
        currentSpeed = isRunning ? runVelocidad : velocidad;

        if (movementX != 0 || movementY != 0)
        {
            Vector3 direccion = (transform.forward * movementY + transform.right * movementX).normalized;
            movimiento = direccion * currentSpeed;
        }
        movimiento.y = myPlayer.linearVelocity.y;
        myPlayer.linearVelocity = movimiento;
    }

    void mouseLook()
    {
        float moveX = Input.GetAxis("Mouse X");
        float moveY = Input.GetAxis("Mouse Y");

        if (moveX != 0)
        {
            transform.Rotate(0, moveX * sensibilidadMouse.x, 0);
        }
        if (moveY != 0)
        {
            camara.Rotate(-moveY * sensibilidadMouse.y, 0, 0);
        }
    }
}

