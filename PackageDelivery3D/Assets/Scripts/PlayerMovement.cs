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
		_tempVector = _tempVector.normalized * movementSpeed * Time.deltaTime;
		rb.MovePosition(transform.position + _tempVector);
	}
}