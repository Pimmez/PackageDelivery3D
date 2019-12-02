using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpikeBehaviour : MonoBehaviour
{
	public static Action<int> SpikeEvent;
	[SerializeField] private int damageAmount = 1;

	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == Tags.Player)
		{
			if(SpikeEvent != null)
			{
				SpikeEvent(damageAmount);
			}
		}
	}
}