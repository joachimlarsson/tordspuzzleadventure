using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance = null;

	int currentLevel = 1;

	public int[,] level1 = new int[,]
	{
		{ 0,0,0,0,0,0,0,0 },
		{ 0,0,0,0,0,0,0,0 },
		{ 0,0,0,0,0,0,0,0 },
		{ 1,1,1,1,1,1,1,1 },
		{ 0,0,0,0,0,0,0,0 },
		{ 0,0,0,0,0,0,0,0 },
		{ 0,0,0,0,0,0,0,0 },
		{ 0,0,0,0,0,0,0,0 }
	};

	public int[,] level2 = new int[,]
{
		{ 0,0,0,0,0,0,0,0 },
		{ 0,0,0,0,0,0,0,0 },
		{ 1,1,1,1,1,1,1,1 },
		{ 0,0,0,0,0,0,0,0 },
		{ 0,0,0,0,0,0,0,0 },
		{ 0,0,0,0,0,0,0,0 },
		{ 0,0,0,0,0,0,0,0 },
		{ 0,0,0,0,0,0,0,0 }
};

	public int[,] currentLevelGrid()
	{
		if (currentLevel == 1)
			return level1;
		if (currentLevel == 2)
			return level2;
		else
		{
			Debug.Log("No more levels added");
			return level1;
		}
	}

	public void levelCompleted()
	{
		Debug.Log("Level completed");
		currentLevel += 1;
		GameManager.instance.LoadLevel();
	}

	public void levelFailed()
	{
		Debug.Log("Level failed");
		GameManager.instance.LoadLevel();
	}

	public int getCurrentLevel()
	{
		return currentLevel;
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
