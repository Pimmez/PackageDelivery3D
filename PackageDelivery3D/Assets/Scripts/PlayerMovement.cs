using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IInput
{
	[SerializeField] private float speed = 5f;
	[SerializeField] private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Movement();
	}

	public void Movement()
	{
		float _moveHorizontal = Input.GetAxis("Horizontal");
		float _moveVertical = Input.GetAxis("Vertical");

		Vector3 _movement = new Vector3(_moveHorizontal, 0.0f, _moveVertical);

		rb.AddForce(_movement * speed, ForceMode.VelocityChange);
	}
}