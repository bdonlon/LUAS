using UnityEngine;
using System.Collections;

public class cameraShake_script : MonoBehaviour {
	
	public float jitter;

	public GameObject GM,camera;
	private float power;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		power = GM.GetComponent<GM_script>().getPowerValue();
		power = -0.5f + power;
		power = power/25;
		jitter = power;
	
		//jitter = 0.001f;
		Vector3 shake = new Vector3 ();
		shake.x = Random.Range(-jitter,jitter);
		shake.y = Random.Range(-jitter,jitter);
		shake.z = camera.transform.position.z;

		if(GM.GetComponent<GM_script>().getPower()){
			camera.transform.position=shake;
		}else{
			camera.transform.position= new Vector3 (0,0,camera.transform.position.z);
		}
	}
}
