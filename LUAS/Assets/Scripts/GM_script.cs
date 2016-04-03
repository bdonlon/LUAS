using UnityEngine;
using System.Collections;

public class GM_script : MonoBehaviour {

	public GameObject key;
	public GameObject accelerator;
	private bool power;
	private float powerValue;

	// Use this for initialization
	void Start () {
		power=false;
		powerValue=0.5f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void togglePower(){
		power = !power;
	}

	public bool getPower(){
		return power;
	}

	public void setPowerValue(float v){
		powerValue = v;
	}
	public float getPowerValue(){
		return powerValue;
	}
}
