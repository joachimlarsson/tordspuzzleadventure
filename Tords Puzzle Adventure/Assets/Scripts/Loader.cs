using UnityEngine;

public class Loader : MonoBehaviour
{
	public GameObject levelManager;
	public GameObject materialManager;
	public GameObject audioManager;

	void Awake()
	{
		if (LevelManager.instance == null)
			Instantiate(levelManager);

		if (MaterialManager.instance == null)
			Instantiate(materialManager);

		if (AudioManager.instance == null)
			Instantiate(audioManager);
	}
}