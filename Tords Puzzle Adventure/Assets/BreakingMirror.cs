using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingMirror : MonoBehaviour
{
	public GameObject mirrorReflection;

	void OnTriggerEnter()
	{
		gameObject.GetComponent<BreakableWindowIgnoreCharacter>().breakWindow();
		mirrorReflection.SetActive(false);	
	}
}
