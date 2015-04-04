	using UnityEngine;
	using UnityEngine.UI;
	using System.Collections;
	

	public class TextController : MonoBehaviour {
	public Text text;
	private enum States {cell, idcard_0, cardsnapped_0, lockport_0, lock_0, lock_1, usb, cell_usb, keypad, unauthorised};
	private States myState;
	public MovieTexture movieTexture;

	// Use this for initializationf\
	
	
	void Start () {
		myState = States.cell;
	}
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.cell) {state_cell();}
		else if (myState == States.idcard_0) 			{state_idcard_0();}
		else if (myState == States.cardsnapped_0) 		{state_cardsnapped_0();}
		else if (myState == States.lock_0) 				{state_lock_0();}
		else if (myState == States.lock_1) 				{state_lock_1();}
		else if (myState == States.lockport_0) 			{state_lockport_0();}
		else if (myState == States.usb) 				{state_usb();}
		else if (myState == States.cell_usb) 			{state_cell_usb();}
		else if (myState == States.keypad) 				{state_keypad();}
		else if (myState == States.unauthorised) 		{state_unauthorised();}
	}
	void state_cell() {
		text.text = "You wake up in room 7821 at Royston Hospital. There is " + 
					"an ID card (0009) on the bed, a usb stick on the floor, and the door " +
					"is locked.\n\n" + 
					"Press C to pick up the card, U to view usb stick and D to view the door" ;
		if (Input.GetKeyDown(KeyCode.C)) {myState = States.idcard_0;}
		else if (Input.GetKeyDown(KeyCode.U)) {myState = States.usb;}
		else if (Input.GetKeyDown(KeyCode.D)) {myState = States.lock_0;}
	}
	void state_idcard_0() {
		text.text = "Maybe this could open the door? \n\n" +
			"Press S to slide the card down over the lock, press C to insert the card into the reader or R to Return to your bedroom" ;
		if (Input.GetKeyDown(KeyCode.S)) {myState = States.cardsnapped_0;}
		else if (Input.GetKeyDown(KeyCode.C)) {myState = States.unauthorised;}			
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}
	void state_cardsnapped_0() {
		text.text = "Damn it! The card does not fit\n\n" +
					"Press R to Return to your bedroom" ;		
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}
	void state_unauthorised() {
		text.text = "*******Unauthorised access******* \n\n" +
					"*******User 0009 was deactivated in March 2031******* \n\n" +
					"Press R to Return to your bedroom";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}
	void state_lock_0() {
		text.text = "There is a card reader next to the door and a small screen.\n\n" +
					"Press K to view the keypad, or R to Return to your bedroom";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
		else if (Input.GetKeyDown(KeyCode.K)) {myState = States.keypad;}
	}
	void state_usb() {
		text.text = "Wow  - usb 3.0, what year is this?! \n\n" +
					"Time does fly \n\n" +
					"Press U to use the usb stick, or R to Return to your bedroom" ;
		if (Input.GetKeyDown(KeyCode.U)) {myState = States.cell_usb;}
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}
	void state_cell_usb() {
		text.text = "There are two usb ports\n\n" +
					"One under the lock and one on the card reader\n\n" +
					"Press L to try the lock port, C to try the card reader port " ;
		if (Input.GetKeyDown(KeyCode.L)) {myState = States.lockport_0;}
		else if (Input.GetKeyDown(KeyCode.C)) {myState = States.lock_1;}
	}
	void state_lockport_0() {
		text.text = "Error! A device connected to the system is not functioning \n\n" +
					"Must be running windows!.\n\n" +
					"Press R to Return to your bedroom" ;
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}
	void state_keypad() {
		text.text = "Please enter authorisation code\n\n"+
					"*   *   *   *\n\n" +
					"Attempt to enter code or press R to Return to your bedroom" ;
		if (Input.GetKeyDown(KeyCode.Alpha9)) Application.LoadLevel("Fail");		
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}
	void state_lock_1() {
		text.text = "*******Unauthorised access******* \n\n" +
					"Alarm will sound in 10seconds\n\n" +
					"Press C to Continue, U to use USB or R to Return to your bedroom" ;	
		if (Input.GetKeyDown(KeyCode.C)) Application.LoadLevel("Complete");
		if (Input.GetKeyDown(KeyCode.U)) {myState = States.cell_usb;}
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell_usb;}
	}
}
