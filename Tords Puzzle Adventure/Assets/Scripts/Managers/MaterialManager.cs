using UnityEngine;

public class MaterialManager : MonoBehaviour
{
	public static MaterialManager instance = null;

	public Material[] materials;

	public Material MaterielCurrentLevel()
	{
		return materials[LevelManager.instance.getCurrentLevel() - 1];
	}

	public Material MaterielForLevel(int level)
	{
		return materials[level - 1];
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
