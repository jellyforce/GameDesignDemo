using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour {

	[Range(1f,5f)]
	public float movementSpeedPlayer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * movementSpeedPlayer * Time.deltaTime, Space.Self);
	}
}
