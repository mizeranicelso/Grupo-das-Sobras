using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraLogic : MonoBehaviour
{
	
	public Texture buttonTexture;
	public Rect buttonLeftPos, buttonRightPos; 

	// Use this for initialization
	void Start ()
	{ 
		buttonLeftPos = new Rect (0, Screen.height / 2 - 25, 50, 50);
		buttonRightPos = new Rect (Screen.width - 50, Screen.height / 2 - 25, 50, 50);
	}
	void OnGUI()
	{
		GUI.backgroundColor = Color.clear;

		if (GUI.Button (buttonLeftPos, buttonTexture)) { //left button
			Debug.LogFormat ("left");
		}

		if (GUI.Button (buttonRightPos, buttonTexture)) { //right button
			Debug.LogFormat ("right");
		}
	
		GUI.DrawTexture (buttonLeftPos, buttonTexture);
		GUI.DrawTexture (buttonRightPos, buttonTexture);
	}

	// Update is called once per frame
	void Update ()
	{

	}
}

