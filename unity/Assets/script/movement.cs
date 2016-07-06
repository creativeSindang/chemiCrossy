using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	Animator _animator;
	
	const int LEFT_DEGREE = 0;
	const int RIGHT_DEGREE = 180;
	const int TOP_DEGREE = 90;
	const int BOTTOM_DEGREE = 270;

	int my_position = 90;

	// Use this for initialization
	void Start () {
		_animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
		if (_animator.GetInteger("Status") == 0 && Input.GetMouseButtonDown(0)){
			transform.Translate(Vector3.forward * 2);
			_animator.SetInteger("Status",2);
		} else if (transform.hasChanged) {
			transform.hasChanged = false;
			_animator.SetInteger("Status",0);

		}

		if (Input.GetMouseButtonDown (0)) {
			Vector3 MousePos = Input.mousePosition;
			bool aResult = A(MousePos.x, MousePos.y);
			bool bResult = B(MousePos.x, MousePos.y);
			if (aResult&& !bResult){
				Debug.Log ("it is left!");
				if (my_position != LEFT_DEGREE) {
					transform.Rotate (0, LEFT_DEGREE-my_position,0);
					my_position = LEFT_DEGREE;
				}
			} else if (!aResult && bResult) {
				Debug.Log ("it is right!");
				if (my_position != RIGHT_DEGREE) {
					transform.Rotate (0, RIGHT_DEGREE-my_position,0);
					my_position = RIGHT_DEGREE;
				}
			} else if (aResult && bResult) {
				Debug.Log ("it is top!");
				if (my_position != TOP_DEGREE) {
					transform.Rotate (0, TOP_DEGREE-my_position,0);
					my_position = TOP_DEGREE;
				}
			} else {
				Debug.Log ("it is bottom");
				if (my_position != BOTTOM_DEGREE) {
					transform.Rotate (0, BOTTOM_DEGREE-my_position,0);
					my_position = BOTTOM_DEGREE;
				}
			}
		}

	}

	bool A(float x, float y) {
		if (y > Screen.height / Screen.width * x) {
			return true;
		} else {
			return false;
		}
	}

	bool B(float x, float y) {
		if (y > Screen.height - Screen.height / Screen.width * x) {
			return true;
		} else {
			return false;
		}
	}
}
