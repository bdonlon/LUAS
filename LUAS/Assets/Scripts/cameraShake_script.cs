using UnityEngine;
using System.Collections;

public class cameraShake_script : MonoBehaviour {
	
	public float jitter;

	public GameObject camera;
	public GameObject accelerator_handle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float power = accelerator_handle.GetComponent<accelerator_script>().power;
		power = -0.5f + power;
		power = power/25;
		jitter = power;
	
		//jitter = 0.001f;
		Vector3 shake = new Vector3 ();
		shake.x = Random.Range(-jitter,jitter);
		shake.y = Random.Range(-jitter,jitter);
		shake.z = camera.transform.position.z;

		camera.transform.position=shake;
	}
}
