using UnityEngine;

public class MovementUpdater : MonoBehaviour
{
	private IInput iinput;

	private void FixedUpdate()
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