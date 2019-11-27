using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IInput
{

    /// <summary>
    /// TODO:
    /// Fix all protected variables from old import in which this class got inherited
    /// Fix the crouch collider disable bug
    /// Fix the dash by actually applying a force instead of a velocity
    /// Clean up
    /// </summary>
    //Declaration of Variables
    [Header("Componenten")]

    [Tooltip("Character Controller Component")]

    [SerializeField] protected CharacterController charController;

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

    [Tooltip("Value voor de snelheid van het crouchen")]
    [SerializeField] protected float crouchSpeed;

    [Tooltip("Value voor de kracht van een dash")]
    [SerializeField] protected float dashForce;

    [Tooltip("Value voor de pauze tussen verschillende dashes")]
    [SerializeField] protected float dashCooldown;

    [Space]

    [Header("Collision en Drop Values")]

    [Tooltip("Dit object geeft aan wat de hoogte van de speler is terwijl hij croucht")]
    [SerializeField] protected Transform ceilingCheck;

    [Tooltip("Dit component geeft de nieuwe collision box van de speler terwijl hij crouched")]
    [SerializeField] protected Collider crouchCollider;

    [Tooltip("De transform van het object wat het laagste punt van de speler aangeeft")]
    [SerializeField] protected Transform groundCheck;

    [Tooltip("De radius van de cirkel die om de groundCheck wordt gecast")]
    [SerializeField] protected float groundDistance = 0.4f;

    [Tooltip("Layermask om te bepalen wat wordt gezien als de Ground")]
    [SerializeField] protected LayerMask groundMask;

    private Vector3 velocity = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 dashVelocity = Vector3.zero;

    protected float forwardMovement;
    protected float sidewaysMovement;

    protected bool jump = false;
    protected bool crouch = false;
    protected bool dash = false;
    protected bool dashing = false;
    private bool isGrounded;

	public void Update()
	{
        Movement();
        jump = false;
        dash = false;
    }

	/// <summary>
	/// This method is public because it derives from IInput (Interface).
	/// </summary>
	public void Movement()
	{
        forwardMovement = Input.GetAxis("Vertical") * forwardSpeed;

        sidewaysMovement = Input.GetAxis("Horizontal") * sidewaysSpeed;

        ///<summary>
        ///This if functions as a replacement for the Normalize vector Function 
        ///as we don't want buggy movement so have to write something ourselves 
        ///that solves the 2 vectors being added to eachother when walking diagonally
        /// </summary>
        if (forwardMovement != 0f && sidewaysMovement != 0f)
        {
            float _forward = forwardMovement;
            float _sideways = sidewaysMovement;
            if (Mathf.Abs(forwardMovement) > Mathf.Abs(sidewaysMovement))
            {
                forwardMovement = Mathf.Clamp(forwardMovement, -forwardSpeed/2f, forwardSpeed/2f);
                sidewaysMovement = Mathf.Clamp(sidewaysMovement, -sidewaysSpeed/2f, sidewaysSpeed/2f);
            }
            else
            {
                sidewaysMovement = Mathf.Clamp(sidewaysMovement, -sidewaysSpeed / 2f, sidewaysSpeed / 2f);
                forwardMovement = Mathf.Clamp(forwardMovement, -forwardSpeed / 2f, forwardSpeed / 2f);
            }
        }

        ///<summary>
        ///Getting all the input from the player
        /// </summary>
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Dash"))
        {
            dash = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            charController.detectCollisions = true;
            crouchCollider.enabled = false;
        }

        moveDirection = new Vector3(sidewaysMovement, 0f, forwardMovement);


        ///<summary>
        ///Activates Crouching which should disable the collider from the character controller and enable a smaller collider
        /// </summary>
        if (crouch)
        {
            Debug.Log("activating Crouch");
            charController.detectCollisions = false;
            crouchCollider.enabled = true;
            moveDirection = moveDirection * crouchSpeed;
        }

        ///<summary>
        ///Adds a force to the player for a limited amount of time when the player hasn't dashed already
        /// </summary>
        if (dash && !dashing)
        {
            StartCoroutine(IsDashing());
            dashVelocity = moveDirection * dashForce;
        }


        ///<summary>
        ///Jumping needs to check if player is on the ground or not, when it is it will apply a vertical velocity to the player
        /// </summary>
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}
		velocity.y += gravity * Time.deltaTime;

		if(jump && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}


        ///<summary>
        ///Adding actual movement to controller
        /// </summary>
        charController.Move(moveDirection * Time.deltaTime);
		charController.Move(velocity * Time.deltaTime);
        charController.Move(dashVelocity * Time.deltaTime);


        ///<summary>
        ///Rotating character to movement direction
        /// </summary>
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
        Debug.Log(charController.detectCollisions);
	}


    /// <summary>
    /// Simple timer to not spam Dashing
    /// </summary>
    IEnumerator IsDashing()
    {
        dashing = true;
        yield return new WaitForSeconds(dashCooldown);
        dashVelocity = Vector3.zero;
        dashing = false;
    }
}