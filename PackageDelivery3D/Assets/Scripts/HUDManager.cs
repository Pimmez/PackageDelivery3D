using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
	[SerializeField] private GameObject joyStick;
	[SerializeField] private GameObject joyButton;

	private void Awake()
    {
		joyButton.SetActive(false);
		joyStick.SetActive(false);

#if UNITY_ANDROID
		//DO ANDROID
		joyButton.SetActive(true);
		joyStick.SetActive(true);
#endif


	}
}