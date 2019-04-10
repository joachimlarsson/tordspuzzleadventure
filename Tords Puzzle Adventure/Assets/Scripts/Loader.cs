using UnityEngine;

public class Loader : MonoBehaviour
{
	public GameObject levelManager;
	public GameObject materialManager;
	public GameObject audioManager;
	public GameObject gameManager;

	void Awake()
	{
		if (LevelManager.instance == null)
			Instantiate(levelManager);

		if (MaterialManager.instance == null)
			Instantiate(materialManager);

		if (AudioManager.instance == null)
			Instantiate(audioManager);

		if (GameManager.instance == null)
			Instantiate(gameManager);
	}
}