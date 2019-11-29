using UnityEngine;
using System;

public class RigidbodyObjects : MonoBehaviour
{
	[SerializeField] private Rigidbody rb;

	private void Awake()
	{
		if(rb == null)
		{
			rb = GetComponent<Rigidbody>();		
		}
	}
}