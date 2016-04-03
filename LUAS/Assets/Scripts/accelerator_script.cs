using UnityEngine;
using System.Collections;

public class accelerator_script : MonoBehaviour {

	public bool touchOrClickButtonPress,dragging;
	public GameObject GM,accelerator,speedMax,speedMin,handleSprite;
	public Vector2 P,A,B,Mid;
	public Vector3 startPosition;
	public float magnitudeAB,ABAPproduct,distance;
	public Sprite[] handle_sprites;
	SpriteRenderer rend1;

	void Start () {
		startPosition = accelerator.transform.position;
		rend1=handleSprite.GetComponent<SpriteRenderer>();
		rend1.sprite=handle_sprites[0];
	}

	void Update () {

		if(GM.GetComponent<GM_script>().getPower()){
			//Mouse clicking button...
			if(Input.GetMouseButtonDown(0)){
				Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
				touchOrClickButtonPress = clickedOrTouched(hitInfo);
			}

			//Mouse release
			if(Input.GetMouseButtonUp(0)){
				rend1.sprite=handle_sprites[0];
				dragging=false;
			}

			if(dragging){
				drag();
			}
		}else{	//make sure accelerator handle is in the 0 position
			accelerator.transform.position=startPosition;
			GM.GetComponent<GM_script>().setPowerValue(0.5f);
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
			GM.GetComponent<GM_script>().setPowerValue(0);
			return A;
		}
		else if (distance > 1){
			GM.GetComponent<GM_script>().setPowerValue(1);
			return B;
		}
		else if(distance>0.45f && distance<0.55f){		//Snap to midpoint
			GM.GetComponent<GM_script>().setPowerValue(0.5f);
			return (A+AB/2);
		}
		else{
			GM.GetComponent<GM_script>().setPowerValue(distance);
			return A+AB*distance;
		}
	}

	public bool clickedOrTouched(RaycastHit2D hitInfo){
		bool hit = false;
		if(hitInfo)
		{
			if(hitInfo.transform.gameObject.name.Equals("handle_object")){
				rend1.sprite=handle_sprites[1];
				dragging=true;
			}
			hit=true;
		}
		return hit;
	}				
}
