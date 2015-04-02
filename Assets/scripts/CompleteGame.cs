using UnityEngine;
using UnityEngine.UI;
using System.Collections;


	public class CompleteGame : MonoBehaviour {
	private enum States {complete};
	private States myState;
	
	// Use this for initializationf\
	void Start () {
		myState = States.complete;
	}
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.complete) {state_complete();}
	}
	void state_complete() {
		if (Input.GetKeyDown(KeyCode.Space)) Application.LoadLevel("Menu");
	}
}