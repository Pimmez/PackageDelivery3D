﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour, IInput
{
	[SerializeField] private float speed = 5f;
	[SerializeField] private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void Movement()
	{
		Debug.Log("DefaultStandalone Movement");

		float _moveHorizontal = Input.GetAxis("Horizontal");
		float _moveVertical = Input.GetAxis("Vertical");

		Vector3 _movement = new Vector3(_moveHorizontal, 0.0f, _moveVertical);

		rb.AddForce(_movement * speed, ForceMode.VelocityChange);
	}

	public void WebMovement()
	{
		Debug.Log("WebGL Movement");

		float _moveHorizontal = Input.GetAxis("Horizontal");
		float _moveVertical = Input.GetAxis("Vertical");

		Vector3 _movement = new Vector3(_moveVertical, 0.0f, _moveHorizontal);

		rb.AddForce(_movement * speed, ForceMode.VelocityChange);
	}

	//DO XBOX
	public void ControllerMovement()
	{
		Debug.Log("Controller Movement");

	}

	//DO ANDROID
	public void MobileMovement()
	{
		Debug.Log("Mobile Movement");

	}
}