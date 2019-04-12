using UnityEngine;
using UnityEngine.UI;

public class CheatsMenu : MonoBehaviour
{
	public GameObject character;
	public GameObject startPlatform;
	public GameObject finishPlatform;

	Vector3 characterStartPosition;
	Vector3 levelStartPlatformPosition;
	Vector3 levelFinishPlatformPosition;

	public bool isVisible = true;

	// GUI
	float menuPosX = 20.0f;
	float menuPosY = 80.0f;
	float menuWidth = 240.0f;
	float menuHeight = 240.0f;

	float buttonPosX = 40.0f;
	float buttonDefaultPosY = 120.0f;
	float buttonPosY;
	float buttonWidth = 200.0f;
	float buttonHeight = 20.0f;
	float buttonSpacingY = 10.0f;

	bool createButton(string description)
	{
		bool isPressed = GUI.Button(new Rect(buttonPosX, buttonPosY, buttonWidth, buttonHeight), description);
		buttonPosY += buttonHeight + buttonSpacingY;
		
		return isPressed;
	}

	void OnGUI()
	{
		if (!isVisible)
			return;

		buttonPosY = buttonDefaultPosY;

		GUI.Box(new Rect(menuPosX, menuPosY, menuWidth, menuHeight), "Cheats");
		if (createButton("TP start pos"))
		{
			character.transform.position = characterStartPosition;
		}
		if (createButton("TP start platform"))
		{
			character.transform.position = levelStartPlatformPosition;
		}
		if (createButton("TP finish platform"))
		{
			character.transform.position = levelFinishPlatformPosition;
		}
		if (createButton("TODO"))
		{
		}
		if (createButton("TODO"))
		{
		}
		if (createButton("Close menu"))
		{
			isVisible = false;
		}
	}

	void Awake()
	{
		characterStartPosition = character.transform.position;
		levelStartPlatformPosition = startPlatform.transform.position;
		levelFinishPlatformPosition = finishPlatform.transform.position;
	}
}
