using UnityEngine;
using System.Collections;

public class ChezbergerController : MonoBehaviour {

	public GameObject Field;
	private int FieldsCreated=1;
	GameObject LastGameObject;
	public GameObject Obstacle;

	// Use this for initialization
	void Start () {

	}
	// 60 times per second
	// Update is called once per frame
	private int CurrentLane=1;
	void Update () {
		if (CurrentLane > 0) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				transform.Translate (new Vector3 (-3.5f, 0, 0));
				CurrentLane--;
			}
		}
		if (CurrentLane < 2) {
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				transform.Translate (new Vector3 (3.5f, 0, 0));
				CurrentLane++;
			}
		}if (transform.position.y<2&&GetComponent<Rigidbody>().velocity.y<2 ){
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			GetComponent<Rigidbody>().AddForce(Vector3.up*350);
		}
		}
		transform.Translate (new Vector3 (0, 0, 0.5f));
	}
	void OnTriggerEnter(Collider col){
		if (FieldsCreated>2){
			Destroy (LastGameObject);
		}
		//for (int i = 0; i < 2; i++) {
		//	int lane = Random.Range (-1, 2);
		//	GameObject newObstacle = Instantiate (Obstacle, new Vector3 (lane * 3.5f, 0.5f, FieldsCreated * 30), Quaternion.identity) as GameObject;
		//}
		LastGameObject=Instantiate (Field, new Vector3(0,0,FieldsCreated*30),Quaternion.identity)as GameObject;
		FieldsCreated++;
	}
}
