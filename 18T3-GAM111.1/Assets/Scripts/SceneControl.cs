using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {

	ScoreManager scoreManager;

	public void LoadStart()
	{
		SceneManager.LoadScene("StartMenu");
	}
	
	public void LoadGame()
	{
		SceneManager.LoadScene("Main");
	}

	public void LoadEnd()
	{
		if(SceneManager.GetActiveScene().name == "Main")
		{
			//scoreManager.SaveScore();
		}
		SceneManager.LoadScene("EndScreen");
	}
}
