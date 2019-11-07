using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EilerController : MonoBehaviour {

	public float l = 2.5F;

	float P;
	float W;

	Rigidbody rb;

	float Pn;
	float Wn;

	float g = 9.8F;

	float fw( float p ) { 
		return -(g/l) * Mathf.Sin(p); 
	}

	float fp( float w ) {
		return w;
	}


	float Eiler ( float angle, float dt, Func<float, float> f) {
		return  dt * f(angle);
	}

	void Start()
	{
		rb = GetComponent<Rigidbody>();

		P = Mathf.PI / 2;
		W = 0;

		Debug.Log (rb.position);
	}

	void Update ()
	{
		float dt = Time.deltaTime;

		Wn = W + Eiler (P, dt, fw);
		Pn = P + Eiler (W, dt, fp);

		rb.position = new Vector3 (
			 l * Mathf.Sin (Pn),  	// x
			-l * Mathf.Cos (Pn),	// y
			rb.position.z			// z
		);

		Debug.Log (rb.position);

		P = Pn;
		W = Wn;
	}
}
