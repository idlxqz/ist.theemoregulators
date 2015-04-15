﻿using UnityEngine;
using System.Collections;

public class IBoxScript : MonoBehaviour {

    //logic control
    public bool finished;
    private float finalWaitStart;
    public float secondsToCloseSession;

    //ibox display
    public Texture2D ibox;

    //memeter and instructions text areas definition
    public Rect iboxArea;
    public Rect instructionsArea;

    //centralized logging
    public Logger log;

    //instruction control
    public string instructions;

    //instructions format
    public GUIStyle instructionsFormat;

	// Use this for initialization
	void Start () {
        finalWaitStart = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        //check if the waiting time is elapsed
        if ((Time.time - finalWaitStart) >= secondsToCloseSession)
            finished = true;
	}

    void OnGUI()
    {
        //draw the instructions text
        GUI.Label(instructionsArea, instructions, instructionsFormat);
        //draw the memeter frame
        GUI.DrawTexture(iboxArea, ibox);
    }
}