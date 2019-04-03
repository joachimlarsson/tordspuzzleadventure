using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMaterialCurrentLevel : MonoBehaviour
{
	void Start()
	{
		MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.material = MaterialManager.instance.MaterielCurrentLevel();
	}
}
