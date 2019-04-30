using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;

	const string levelScene = "LevelScene";
	const string lobbyScene = "LobbyScene";
	const string tutorialElevatorScene = "TutorialElevatorScene";
	const string mainMenuScene = "MenuScene";

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

		AudioManager.instance.Play("MainMenu");
	}

	public void LoadLobby()
	{
		Initiate.Fade(lobbyScene, Color.black, 0.5f);
	}

	public void LoadTutorial()
	{
		Initiate.Fade(tutorialElevatorScene, Color.black, 0.5f);
		AudioManager.instance.PlayAfterTime("Theme", 2.0f);
	}

	public void LoadLevel()
	{
		Initiate.Fade(levelScene, Color.black, 0.5f);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void LoadMainMenu()
	{
		Initiate.Fade(mainMenuScene, Color.black, 0.5f);
	}
}
