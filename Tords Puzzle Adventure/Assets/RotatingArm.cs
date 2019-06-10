using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingArm : MonoBehaviour
{
	public GameObject rotatingArm;
	public GameObject playerObject;

	public float Angle = 0.15f;

    void Update()
    {
		rotatingArm.transform.Rotate(0.0f, Angle, 0.0f, Space.Self);
	}
	
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.transform.SetParent(rotatingArm.transform, true);
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.transform.parent = null;
		}
	}
}
