using UnityEngine;
using System.Collections;

public class floorMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float delta = Time.deltaTime * 1;

		transform.Translate(Vector3.left * delta);
		if (Input.GetMouseButtonDown(0)){
			transform.Translate(Vector3.left);
		}
	}
}
