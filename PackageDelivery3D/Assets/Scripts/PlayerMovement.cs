using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IInput
{
	[SerializeField] private float movementSpeed = 4f;
	[SerializeField] private float jumpHeight = 2f;
	[SerializeField] private float gravity = -9.81f;
	private bool isGrounded;


	[Header("Collision en Drop Values")]

	[Tooltip("De transform van het object wat het laagste punt van de speler aangeeft")]
	[SerializeField] protected Transform groundCheck;

	[Tooltip("De radius van de cirkel die om de groundCheck wordt gecast")]
	[SerializeField] protected float groundDistance = 0.4f;

	[Tooltip("Layermask om te bepalen wat wordt gezien als de Ground")]
	[SerializeField] protected LayerMask groundMask;

	[SerializeField] private CharacterController charController;

	private Vector3 velocity = Vector3.zero;

	private Vector3 moveDirection = Vector3.zero;

	private void Awake()
	{
		charController = GetComponent<CharacterController>();
	}

	/// <summary>
	/// FixedUpdate for Rigidbody and physics related actions.
	/// </summary>
	public void Update()
	{
		Movement();
	}

	/// <summary>
	/// This method is public because it derives from IInput (Interface).
	/// </summary>
	public void Movement()
	{
		float _horizontal = Input.GetAxis("Horizontal");
		float _vertical = Input.GetAxis("Vertical");

		moveDirection = new Vector3(_horizontal, 0f, _vertical);

		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}
		velocity.y += gravity * Time.deltaTime;

		if(Input.GetButton("Jump") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}

		moveDirection *= movementSpeed;

		charController.Move(moveDirection * Time.deltaTime);
		charController.Move(velocity * Time.deltaTime);
		if (moveDirection != Vector3.zero)
			transform.rotation = Quaternion.LookRotation(moveDirection);

		/*
		float _horizontal = Input.GetAxisRaw("Horizontal");
		float _vertical = Input.GetAxisRaw("Vertical");

		Vector3 _tempVector = new Vector3(_horizontal, 0, _vertical);

		//_tempVector.normalized because otherwise if you walk diagonal you wil walk faster.
		_tempVector = _tempVector.normalized * movementSpeed * Time.deltaTime;

		//transform.rotation = Quaternion.LookRotation(_tempVector);
		rb.MovePosition(transform.position + _tempVector);
		if (_tempVector != Vector3.zero)
		{
			// Do the rotation here
			rb.MoveRotation(Quaternion.LookRotation(_tempVector));
		}
		*/

		/*
		//Move relative to world space (so rotation doesn't affect movement)
		float _x = movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
		float _z = movementSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
		transform.Translate(_x, 0f, _z, Space.World);

		//Work out angle using atan 2
		float angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;

		//Prevent cube snapping to angle if there is no movement
		if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
			transform.rotation = Quaternion.Euler(0f, angle, 0f);
		*/
	}
}