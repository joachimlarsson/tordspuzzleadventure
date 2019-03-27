using UnityEngine;

public class Loader : MonoBehaviour
{
	public GameObject levelManager;

	void Awake()
	{
		if (LevelManager.instance == null)
			Instantiate(levelManager);
	}
}