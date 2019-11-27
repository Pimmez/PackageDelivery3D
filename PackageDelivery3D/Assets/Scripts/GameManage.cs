using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
	public IInput test;

	// Start is called before the first frame update
	private void Start()
	{
		//IInput iinput = GetComponent(typeof(IInput)) as IInput;
		//iinput.TestingDebugs();

		//IInput myInterface = (IInput)GetComponent(typeof(IInput));
		//myInterface.TestingDebugs();

		/*
		test = (IInput)GetComponent(typeof(IInput));
		if (test != null)
			test.TestingDebugs();
		*/
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == Tags.Player)
		{
			IInput iinput = (IInput)other.gameObject.GetComponent(typeof(IInput));
			if (iinput != null)
			{
				iinput.TestingDebugs();
			}
		}
	}
}