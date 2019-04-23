using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyFinished : MonoBehaviour
{
	public float finishedPos = -4.5f;
	bool runOnce = false;

    void Update()
    {
        if (!runOnce && transform.position.y < finishedPos)
		{
			GameManager.instance.LoadTutorial();
			runOnce = true;
		}
    }
}
