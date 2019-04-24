using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailed : MonoBehaviour
{
	public float posY = -4.5f;
	bool runOnce = false;

    void Update()
    {
        if (!runOnce && transform.position.y < posY)
		{
			LevelManager.instance.levelFailed();
			runOnce = true;
		}
    }
}
