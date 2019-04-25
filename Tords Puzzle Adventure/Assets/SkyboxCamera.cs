using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxCamera : MonoBehaviour
{
	public Camera MainCamera;
	public Camera SkyCamera;
	public Vector3 SkyBoxRotation;
	
	void Start()
	{
		if (SkyCamera.depth >= MainCamera.depth)
		{
			Debug.Log("Set skybox camera depth lower than main camera depth in inspector");
		}
		if (MainCamera.clearFlags != CameraClearFlags.Nothing)
		{
			Debug.Log("Main camera needs to be set to dont clear in the inspector");
		}

		SkyCamera.transform.position = MainCamera.transform.position;
		SkyCamera.transform.rotation = MainCamera.transform.rotation;
		SkyCamera.transform.Rotate(SkyBoxRotation);
	}

	// if you need to rotate the skybox during gameplay
	// rotate the skybox independently of the main camera
	public void SetSkyBoxRotation(Vector3 rotation)
	{
		this.SkyBoxRotation = rotation;
	}

	// Update is called once per frame
	void Update()
	{
		//SkyCamera.transform.position = MainCamera.transform.position;
		//SkyCamera.transform.rotation = MainCamera.transform.rotation;
		SkyCamera.transform.Rotate(0.0f, transform.rotation.y * Time.deltaTime, 0.0f);
	}
}
