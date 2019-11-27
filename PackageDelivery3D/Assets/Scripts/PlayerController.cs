using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Declaration of Variables
    [Header("Classes")]

    [Tooltip("Script voor de PlayerMotor")]
    [SerializeField] private PlayerMotor motor;

    [Space]

    [Header("Componenten")]

    [Tooltip("Character Controller Component")]

    [SerializeField] protected CharacterController controller;

    [Space]

    [Header("Movement Values")]

    [Tooltip("Value voor voorwaartse Beweging")]
    [SerializeField] private float forwardSpeed;

    [Tooltip("Value voor zijwaartse Beweging")]
    [SerializeField] private float sidewaysSpeed;

    [Tooltip("Value voor SprongHoogte")]
    [SerializeField] protected float jumpHeight;

    [Tooltip("Value voor Zwaartekracht")]
    [SerializeField] protected float gravity;

    [Space]

    [Header("Collision en Drop Values")]

    [Tooltip("De transform van het object wat het laagste punt van de speler aangeeft")]
    [SerializeField] protected Transform groundCheck;

    [Tooltip("De radius van de cirkel die om de groundCheck wordt gecast")]
    [SerializeField] protected float groundDistance = 0.4f;

    [Tooltip("Layermask om te bepalen wat wordt gezien als de Ground")]
    [SerializeField] protected LayerMask groundMask;

    protected float forwardMovement;
    protected float sidewaysMovement;

    protected bool jump = false;
    protected bool crouch = false;

    private void Update()
    {
    /// <summary>
    /// In deze reeks worden de Values van forwardMovement en sidewaysMovement aangepast als de Input veranderd
    /// </summary>
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            forwardMovement = Input.GetAxisRaw("Vertical") * forwardSpeed * Time.deltaTime;
        }
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            sidewaysMovement = Input.GetAxisRaw("Horizontal") * sidewaysSpeed * Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
    }

    private void FixedUpdate()
    {
        motor.Move(forwardMovement, sidewaysMovement, jump, crouch);
        jump = false;
    }
}
