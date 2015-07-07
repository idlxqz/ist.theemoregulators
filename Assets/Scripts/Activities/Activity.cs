﻿using UnityEngine;

public class Activity : MonoBehaviour
{
    protected StandardConfigurations Configurations;
    protected SensorManager SensorManager;
    public bool CanContinue;
    public string Description;

	//Getters and Setters
	public bool IsMultiLineSet { get; set; }
	public bool IsMultiLine { get; set; }

    protected virtual void Awake()
    {
        this.Configurations = GameObject.FindObjectOfType<StandardConfigurations>();
        this.SensorManager = GameObject.FindObjectOfType<SensorManager>();
    }

    public virtual void Start()
    {
        this.CanContinue = false;
        this.SensorManager.StartNewActivity();
    }

	//TheEmoregulators usage
	public virtual void WriteInstruction(string instruction, bool isMultiLine)
	{
	}
	
	public virtual void EnableEnd()
	{

		Debug.Log ("EnableEnd Activity");
	}
	//TheEmoregulators usage

    public virtual void EndActivity()
    {
        this.enabled = false;

        Logger.Instance.LogInformation("Player score: " + SessionManager.PlayerScore);
        Logger.Instance.LogInformation("Activity HR (Avg,Min,Max): " + SensorManager.Avg(this.SensorManager.CurrentActivityHeartRateSamples) + "," + SensorManager.Min(this.SensorManager.CurrentActivityHeartRateSamples) + "," + SensorManager.Max(this.SensorManager.CurrentActivityHeartRateSamples));
        Logger.Instance.LogInformation("Activity EDA (Avg,Min,Max): " + SensorManager.Avg(this.SensorManager.CurrentActivityEDASamples) + "," + SensorManager.Min(this.SensorManager.CurrentActivityEDASamples) + "," + SensorManager.Max(this.SensorManager.CurrentActivityEDASamples));
        Logger.LogPhysiologicalSignals(this.Description,this.SensorManager.CurrentActivityHeartRateSamples, this.SensorManager.CurrentActivityEDASamples);
    }
}
