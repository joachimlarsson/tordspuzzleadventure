using UnityEngine;
using UnityEngine.UI;

public class CheatsMenu : MonoBehaviour
{
	public GameObject character;
	public bool isVisible = true;

	Vector3 characterStartPosition;

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
		if (createButton("Teleport character"))
		{
			character.transform.position = characterStartPosition;
		}
		if (createButton("TODO"))
		{
		}
		if (createButton("TODO"))
		{
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
	}
}
