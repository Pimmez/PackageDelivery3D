using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	private int health;
	[SerializeField] private int maxHealth = 1;

    // Start is called before the first frame update
    private void Start()
    {
		health = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        if(health <= 0)
		{
			Debug.Log("Death");
			//Respawn

			Destroy(this.gameObject);
		}
    }

	private void healthDecrease(int _damageAmount)
	{
		health -= _damageAmount;
		//throw new NotImplementedException();
	}

	private void OnEnable()
	{
		SpikeBehaviour.SpikeEvent += healthDecrease;
	}

	private void OnDisable()
	{
		SpikeBehaviour.SpikeEvent -= healthDecrease;
	}

}