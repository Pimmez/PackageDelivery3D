using UnityEngine;
using System;

public class RigidbodyObjects : MonoBehaviour
{
	public static Action<Rigidbody> RigidOjbectsEvent;

	[SerializeField] private Rigidbody rb;
	[SerializeField] private LayerMask layerMask;
	[SerializeField] private string ConveyorBeltName = "ConveyorBelt";

	private int raycastDistance = 5;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();		
	}

	private void FixedUpdate()
	{
		/*
		RaycastHit _hit;

		if (Physics.Raycast(transform.position, Vector3.down, out _hit, raycastDistance, layerMask))
		{
			if (_hit.collider.name == ConveyorBeltName)
			{
				Debug.Log("BELTCONVEYOR ACTIVATED");
				if (RigidOjbectsEvent != null)
				{
					RigidOjbectsEvent(rb);
				}
			}
		}
		*/
	}
}