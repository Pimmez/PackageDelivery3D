using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IInput
{
	[SerializeField] private float movementSpeed = 4f;
	[SerializeField] private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	/// <summary>
	/// FixedUpdate for Rigidbody and physics related actions.
	/// </summary>
	private void FixedUpdate()
	{
		Movement();
	}

	/// <summary>
	/// This method is public because it derives from IInput (Interface).
	/// </summary>
	public void Movement()
	{
		
		float _horizontal = Input.GetAxisRaw("Horizontal");
		float _vertical = Input.GetAxisRaw("Vertical");

		Vector3 _tempVector = new Vector3(_horizontal, 0, _vertical);

		//_tempVector.normalized because otherwise if you walk diagonal you wil walk faster.
		_tempVector = _tempVector.normalized * movementSpeed * Time.deltaTime;

		//transform.rotation = Quaternion.LookRotation(_tempVector);
		rb.MovePosition(transform.position + _tempVector);
		rb.MoveRotation(Quaternion.LookRotation(_tempVector));
		

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

	/// <summary>
	/// interface test
	/// </summary>
	public void TestingDebugs()
	{
		Debug.Log("Test TestingDebugs");
	}
}