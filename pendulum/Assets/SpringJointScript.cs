using UnityEngine;
using System.Collections;

public class SpringJointScript : MonoBehaviour {
	
	public float A = 0.01f;
	public float k = 0.05f;
	public float start_fase;
	public float cyclic_frequency;

	private float time;
	private float coordY = 0;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		cyclic_frequency = Mathf.Sqrt (k / rb.mass);
		time = 0;
		start_fase = - cyclic_frequency * time;
	}
	
	// Update is called once per frame
	void Update () {
		
		time = Time.realtimeSinceStartup;
		//transform.translate.y = A * Mathf.Sin ( start_fase + cyclic_frequency * time );

		coordY = A * Mathf.Cos (start_fase + cyclic_frequency * time);

		rb.MovePosition ( new Vector3( 
			0f,
			coordY,
			0f
		));
	}
}
