using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
	[SerializeField] private float objectSpeed = 15f;
	[SerializeField] private float playerSpeed = 15f;

	[SerializeField] private Vector3 beltDirection = Vector3.zero;

	private void OnCollisionStay(Collision other)
	{
		if(other.gameObject.tag != Tags.Player)
		{
			float _beltVelocity = objectSpeed * Time.deltaTime;
			other.gameObject.GetComponent<Rigidbody>().AddForce(_beltVelocity * beltDirection, ForceMode.VelocityChange);

		}
		else
		{
			float _beltVelocity = playerSpeed * Time.deltaTime;
			other.gameObject.GetComponent<Rigidbody>().AddForce(_beltVelocity * beltDirection, ForceMode.VelocityChange);
		}
	}
	
	private void OnCollisionExit(Collision other)
	{
		if(other.gameObject.tag != Tags.Player)
		{
			other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}
}