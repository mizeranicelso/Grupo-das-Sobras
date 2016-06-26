using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraLogic : MonoBehaviour
{
	
	public Texture buttonRightTex, buttonLeftTex, barTex, pinTex;
	public Rect buttonLeftPos, buttonRightPos,barPos, pinPos, scoreLabelPos;
	private int score = 0;
	private bool left = false, gamePaused = true;
	private Rect lastPinPos;


	void Start ()
	{ 
		buttonLeftPos = new Rect (0, Screen.height / 2 - 25, 50, 50);
		buttonRightPos = new Rect (Screen.width - 50, Screen.height / 2 - 25, 50, 50);
		barPos = new Rect (0, Screen.height - 10, Screen.width, 10);
		pinPos = new Rect (Screen.width/2 - 10, Screen.height - 30, 20, 20);
		lastPinPos = new Rect (Screen.width/2 - 10, Screen.height - 30, 20, 20);
		scoreLabelPos = new Rect (0, 20, 100, 20);
	}
	void OnGUI()
	{
		GUI.backgroundColor = Color.clear;
	
		if (GUI.Button (buttonLeftPos, buttonLeftTex)) { //left button
			gamePaused = false;
			left = true;
		}

		if (GUI.Button (buttonRightPos, buttonRightTex)) { //right button
			gamePaused = false;
			left = false;
		}
	
		GUI.TextField (scoreLabelPos, score.ToString ());
		GUI.DrawTexture (buttonLeftPos, buttonLeftTex);
		GUI.DrawTexture (buttonRightPos, buttonRightTex);
		GUI.DrawTexture (barPos, barTex);
		GUI.DrawTexture (pinPos, pinTex);
	}

	void Update ()
	{
		if (left && !gamePaused) // left button pressed
			pinPos.x = pinPos.x - 2;

		if (!left && !gamePaused) // right button pressed
			pinPos.x = pinPos.x + 2;

		// score logic
		if ((lastPinPos.center.x >= (Screen.width/2) && pinPos.center.x < (Screen.width/2)) ||(lastPinPos.center.x < (Screen.width/2) && pinPos.center.x >= (Screen.width/2)))
			score++;
		lastPinPos = pinPos;
	}
}

