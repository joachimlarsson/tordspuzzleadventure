using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;

	const string levelScene = "LevelScene";
	const string lobbyScene = "LobbyScene";
	const string tutorialElevatorScene = "TutorialElevatorScene";

	void Awake()
    {
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);
	}

	public void LoadLobby()
	{
		SceneManager.LoadScene(lobbyScene);
	}

	public void LoadTutorial()
	{
		SceneManager.LoadScene(tutorialElevatorScene);
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene(levelScene);
	}
}
