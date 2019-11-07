using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RungeKutta4Controller : MonoBehaviour {

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

	float Runge ( float angle, float dt, Func<float, float> f) {
		float k1, k2, k3, k4;
		k1 = k2 = k3 = k4 = 0;

		k1 = dt * f(angle);
		k2 = dt * f(angle + (1 / 2) * k1);
		k3 = dt * f(angle + (1 / 2) * k2);
		k4 = dt * f(angle + k3);

		return  k1 / 6 + 2 * k2 / 6 + 2 * k3 / 6 + k4 / 6;
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

		Wn = W + Runge (P, dt, fw);
		Pn = P + Runge (W, dt, fp);

		rb.position = new Vector3 (
			 l * Mathf.Sin (Pn),	// x
			-l * Mathf.Cos (Pn),	// y
			rb.position.z			// z
		);
		
		Debug.Log (rb.position);

		P = Pn;
		W = Wn;
	}
}
