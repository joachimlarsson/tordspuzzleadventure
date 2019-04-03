using UnityEngine;

public class Loader : MonoBehaviour
{
	public GameObject levelManager;
	public GameObject materialManager;

	void Awake()
	{
		if (LevelManager.instance == null)
			Instantiate(levelManager);

		if (MaterialManager.instance == null)
			Instantiate(materialManager);
	}
}