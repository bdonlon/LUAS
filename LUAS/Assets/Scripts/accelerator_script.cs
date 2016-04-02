using UnityEngine;
using System.Collections;

public class accelerator_script : MonoBehaviour {

	public bool touchOrClickButtonPress,dragging;
	public GameObject accelerator,speedMax,speedMin;
	public Vector2 P,A,B,Mid;
	public float magnitudeAB,ABAPproduct,distance;
	public float power;

	void Start () {
		power=0.5f;
	}

	void Update () {
		
		//Mouse clicking button...
		if(Input.GetMouseButtonDown(0)){
			Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
			touchOrClickButtonPress = clickedOrTouched(hitInfo);
		}

		//Mouse release
		if(Input.GetMouseButtonUp(0)){dragging=false;}

		if(dragging){
			drag();
		}			
	}

	void drag() {
		accelerator.transform.position= closestPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}

	public Vector3 closestPoint(Vector3 mousePosition){
		P = new Vector2 (mousePosition.x,mousePosition.y);
		A = new Vector2 (speedMin.transform.position.x,speedMin.transform.position.y);	// speedMin collider
		B = new Vector2 (speedMax.transform.position.x,speedMax.transform.position.y);	// speedMax collider
		Vector2 AP = P - A;
		Vector2 AB = B - A;
		magnitudeAB = AB.sqrMagnitude;     //Magnitude of AB vector (it's length squared)     
		ABAPproduct = Vector2.Dot(AP, AB);    //The DOT product of a_to_p and a_to_b     
		distance = ABAPproduct / magnitudeAB; //The normalized "distance" from a to your closest point 

		if (distance < 0){    //Check if P projection is over vectorAB     
			power = 0;
			return A;
		}
		else if (distance > 1){
			power = 1;
			return B;
		}
		else{
			power = distance;
			return A+AB*distance;
		}
	}

	public bool clickedOrTouched(RaycastHit2D hitInfo){
		bool hit = false;
		if(hitInfo)
		{
			if(hitInfo.transform.gameObject.name.Equals("handle_object")){
				dragging=true;
			}
			hit=true;
		}
		return hit;
	}
				
}
