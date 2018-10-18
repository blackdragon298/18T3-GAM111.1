using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	SceneControl sceneControl;
	GameObject player;

	// Use this for initialization
	void Start () {
		sceneControl = GetComponent<SceneControl>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<Health>().GetHealth() <= 0)
		{
			sceneControl.LoadEnd();
		}
	}
}
