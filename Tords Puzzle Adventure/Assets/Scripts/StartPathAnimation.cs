using UnityEngine;

public class StartPathAnimation : MonoBehaviour
{
	public void StartAnimation()
	{
		RotatingTile[] children = GetComponentsInChildren<RotatingTile>();
		foreach (RotatingTile child in children)
		{
			child.StartPathAnimation();
		}
	}
}