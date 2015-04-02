using UnityEngine;
using System.Collections;

public class ButtonStartGame : MonoBehaviour 
{
	public void StartGameButton(int Game)
	{
		Application.LoadLevel(Game);
	}
}