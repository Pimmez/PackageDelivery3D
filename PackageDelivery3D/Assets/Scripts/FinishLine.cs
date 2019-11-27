using UnityEngine;
using System;

public class FinishLine : MonoBehaviour
{
	public static Action finishEvent;

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == Tags.Player)
		{
			Debug.Log("Finish!!");
			if(finishEvent != null)
			{
				finishEvent();
			}
		}
	}
}