using UnityEngine;
using UnityEngine.UI;
using System.Collections;


	public class StartGame : MonoBehaviour {
	private enum States {newgame};
	private States myState;
	public Text text;
	
	// Use this for initializationf\
	void Start () {
		myState = States.newgame;
	}
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.newgame) {state_newgame();}
	}
	void state_newgame() {
		text.text = "Welcome to Royston Hospital \n\n" +
					"Hit SPACE to start the game";
		if (Input.GetKeyDown(KeyCode.Space)) Application.LoadLevel("Game");
	}
}