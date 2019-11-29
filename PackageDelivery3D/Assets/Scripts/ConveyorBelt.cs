using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
	[SerializeField] private Vector3 adjustMovement;
	[SerializeField] private Vector3 beltDirection;

	private void OnCollisionStay(Collision obj)
	{
		if (obj.gameObject.tag != Tags.Player)
		{
			float beltVelocity = 1 * Time.deltaTime;
			obj.gameObject.GetComponent<Rigidbody>().velocity = beltVelocity * beltDirection;
		}
		else
		{
			return;
		}
	}

	private void MovingBeltPlayer(CharacterController _charController)
	{
		_charController.SimpleMove(adjustMovement);
	}

	private void OnEnable()
	{
		PlayerMovement.ConveyorBeltEvent += MovingBeltPlayer;
	}

	private void OnDisable()
	{
		PlayerMovement.ConveyorBeltEvent -= MovingBeltPlayer;
	}
}