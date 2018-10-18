using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	int currentScore;

	public void IncreaseScore(int amount)
	{
		currentScore += amount;
	}

	// Leaving this for now, will return to it if i have time when other requirements are met
	/*public void SaveScore()
	{
		int tempScore;
		if (currentScore > PlayerPrefs.GetInt("Score1"))
		{
			tempScore = PlayerPrefs.GetInt("Score1");
			PlayerPrefs.SetInt("Score1", currentScore);
		}
	}*/
	
	/*  
	 *  i know i need to take the player's score and compare it to the other scores     
	 *  and find where the player's score fits on the score board, that part is simple  
	 *  its then a matter of how to bump down all the scores below the new score, which 
	 *  is the part i can't seem to figue out.
	 */ 

	public int GetScore()
	{
		return currentScore;
	}
}
