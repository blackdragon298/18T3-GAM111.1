using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 location = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
		transform.position = location;
		
		//transform.Translate(location * Time.deltaTime);
	}
}