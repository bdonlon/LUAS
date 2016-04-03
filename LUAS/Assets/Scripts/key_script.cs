using UnityEngine;
using System.Collections;

public class key_script : MonoBehaviour {

	public bool touchOrClickButtonPress;
	public GameObject GM,key,LED;
	public Sprite[] key_sprites;
	public Sprite[] LED_sprites;
	SpriteRenderer keyRend,LEDRend;

	// Use this for initialization
	void Start () {
		keyRend=key.GetComponent<SpriteRenderer>();
		LEDRend=LED.GetComponent<SpriteRenderer>();
		keyRend.sprite=key_sprites[0];
		LEDRend.sprite=LED_sprites[0];
	}
	
	// Update is called once per frame
	void Update () {
	
		//Mouse clicking button...
		if(Input.GetMouseButtonDown(0)){
			Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
			touchOrClickButtonPress = clickedOrTouched(hitInfo);
		}
	}

	public bool clickedOrTouched(RaycastHit2D hitInfo){
		bool hit = false;
		if(hitInfo)
		{
			if(hitInfo.transform.gameObject.name.Equals("key")){
				if(GM.GetComponent<GM_script>().getPower()){
					keyRend.sprite=key_sprites[0];
					LEDRend.sprite=LED_sprites[0];
				}else{
					keyRend.sprite=key_sprites[1];
					LEDRend.sprite=LED_sprites[1];
				}
				GM.GetComponent<GM_script>().togglePower();
			}
			hit=true;
		}
		return hit;
	}
}
