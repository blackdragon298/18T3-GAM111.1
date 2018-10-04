using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		Color myColor;
		myColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));

		SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
		sr.color = myColor;
	}
}
