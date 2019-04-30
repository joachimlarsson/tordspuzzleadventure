using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance = null;
	public TextAsset[] levels;

	int currentLevel = 0;
	List<int[,]> allLevels = new List<int[,]>();

	public int[,] currentLevelGrid()
	{
		return allLevels[currentLevel];
	}

	public void levelCompleted()
	{
		currentLevel += 1;
		GameManager.instance.LoadLevel();
	}

	public void tutorialCompleted()
	{
		GameManager.instance.LoadLevel();
	}

	public void levelFailed()
	{
		currentLevel -= 1;
		currentLevel = Mathf.Max(0, currentLevel);
		if (currentLevel == 0)
			GameManager.instance.LoadTutorial();
		else
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

		Initialize();
	}

	void Initialize()
	{
		for (int i = 0; i < levels.Length; i++)
		{
			TextAsset level = levels[i];
			if (level != null)
			{
				string[] rows = level.text.Split('\n');
				int[,] levelCollection = new int[rows.Length, rows.Length];
				for (int r = 0; r < rows.Length - 1; r++)
				{
					string row = rows[r];
					for (int c = 0; c < row.Length - 1; c++)
					{
						char col = row[c];
						levelCollection[r, c] = (int)Char.GetNumericValue(col); ;
					}
				}

				allLevels.Add(levelCollection);
			}
		}
	}
}
