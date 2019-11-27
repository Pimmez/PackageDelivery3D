using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
	private void EndScoreCalculations()
	{
		Debug.Log("Total Score is something");
	}

	private void Update()
	{
		//Enum GameStates
		//GameStates :: Menu 
		//GameStates :: Game
		//GameStates :: Pause
		//GameStates :: Win
		//GameStates :: Lose
	}

	private void OnEnable()
	{
		FinishLine.finishEvent += EndScoreCalculations;		
	}

	private void OnDisable()
	{
		FinishLine.finishEvent -= EndScoreCalculations;
	}
}