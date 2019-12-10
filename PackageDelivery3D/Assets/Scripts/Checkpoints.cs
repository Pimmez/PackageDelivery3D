using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
	[SerializeField] private List<GameObject> checkpointList = new List<GameObject>();

	private void OnTriggerEnter(Collider other)
	{
		//PlayerMovement player = (PlayerMovement)GameObject.Find("Player").GetComponent("PlayerMovement");

		//player.currentCheckPoint = this.gameObject;
	}

}