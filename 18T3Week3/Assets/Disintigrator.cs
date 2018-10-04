using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disintigrator : MonoBehaviour {

	public string destroyTag;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		GameObject subject = other.gameObject;

		if (subject.tag == destroyTag)
		{
			Destroy(subject);
		}
	}
}
