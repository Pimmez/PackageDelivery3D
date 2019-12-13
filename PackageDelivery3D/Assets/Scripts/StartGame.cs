using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
	public void ActivateLevel(int _chooseLevel)
	{
		SceneManager.LoadScene(_chooseLevel);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}