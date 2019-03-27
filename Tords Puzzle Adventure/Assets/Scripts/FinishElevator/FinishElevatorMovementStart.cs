using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishElevatorMovementStart : MonoBehaviour
{
	bool start = false;
	Vector3 startPosition;
	bool runOnce = false;

	public void StartElevator()
	{
		start = true;
	}

	void Awake()
	{
		startPosition = transform.position;
	}

	void Update()
	{
		if (start)
		{
			transform.position += new Vector3(0, 0.4f * Time.deltaTime, 0);
			if (!runOnce && transform.position.y > 2.0f * startPosition.y)
			{
				LevelManager.instance.levelCompleted();
				runOnce = true;
			}
		}
	}
}
