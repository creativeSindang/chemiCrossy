using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	Animator _animator;
	// Use this for initialization
	void Start () {
		_animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
		if (_animator.GetInteger("Status") == 0 && Input.GetMouseButtonDown(0)){
			Debug.Log ("Clicked");
			transform.Translate(Vector3.forward);
			_animator.SetInteger("Status",2);
		} else if (transform.hasChanged) {
			Debug.Log ("Changed");
			transform.hasChanged = false;
			_animator.SetInteger("Status",0);
		}

	}
}
