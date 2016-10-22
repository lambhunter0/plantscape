using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	float pSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);

		if (direction != Vector3.zero) {
			transform.position += direction * pSpeed * Time.deltaTime;
		}
	}
}
