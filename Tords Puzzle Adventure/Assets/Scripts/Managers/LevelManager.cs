using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance = null;

	public void levelCompleted()
	{
		Debug.Log("Level completed");
	}

	public void levelFailed()
	{
		Debug.Log("Level failed");
	}

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}
}
