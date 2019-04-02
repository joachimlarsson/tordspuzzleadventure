using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CreateLevelGrid : MonoBehaviour
{
	void Start()
	{
		Transform[] allTransforms = GetComponentsInChildren<Transform>();
		Renderer[] childRenderers = GetComponentsInChildren<Renderer>();
		Rigidbody[] childRigidBodies = GetComponentsInChildren<Rigidbody>();
		Collider[] childColliders = GetComponentsInChildren<Collider>();
		Transform[] childTransforms = allTransforms.Skip(1).ToArray(); // Remove parent (Grid transform)

		List<GameObject> childrenList = new List<GameObject>();
		foreach (Transform child in childTransforms)
		{
			childrenList.Add(child.gameObject);
		}
		
		for (int i = 0; i < childTransforms.Length; i++)
		{
			Transform transform = childTransforms[i];
			Renderer renderer = childRenderers[i];
			Rigidbody rigidBody = childRigidBodies[i];
			Collider collider = childColliders[i];
			
			if (LevelManager.instance.currentLevelGrid()[(int)transform.position.x, (int)transform.position.z] == 1)
			{
				rigidBody.isKinematic = true;
				collider.isTrigger = false;
			}
			else
			{
				collider.isTrigger = true;
				rigidBody.isKinematic = false;
			}
		}
	}
}
