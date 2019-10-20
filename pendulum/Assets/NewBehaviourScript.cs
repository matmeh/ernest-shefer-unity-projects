using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	Rigidbody rb;

	// Use this for initialization
	void Start () {
	

		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3(0, 10, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
