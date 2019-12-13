using UnityEngine;

public class MovementUpdater : MonoBehaviour
{
	private IInput iinput;

	private bool isMovementActive = false;

	private void Awake()
	{
		isMovementActive = true;
	}

	private void FixedUpdate()
	{
		if (isMovementActive == true)
		{
			iinput = GetComponent(typeof(IInput)) as IInput;

#if UNITY_STANDALONE_WIN
			iinput.Movement();
#endif

#if UNITY_WEBGL
	//DO WEB
		iinput.WebMovement();
#endif

#if UNITY_XBOXONE
	//DO XBOX
		iinput.ControllerMovement();
#endif

#if UNITY_ANDROID
	//DO ANDROID
		iinput.MobileMovement();
#endif

		}
	}

	private void StopMovement()
	{
		isMovementActive = false;
	}

	private void OnEnable()
	{
		FinishLine.finishEvent += StopMovement;
	}

	private void OnDisable()
	{
		FinishLine.finishEvent -= StopMovement;
	}
}