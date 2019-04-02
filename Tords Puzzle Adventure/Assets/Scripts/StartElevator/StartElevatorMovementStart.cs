using UnityEngine;

public class StartElevatorMovementStart : MonoBehaviour
{
	public float endPositionY = 0.0f;

	void Update()
	{
		if (transform.position.y < endPositionY)
		{
			transform.position += new Vector3(0, 0.4f * Time.deltaTime, 0);
		}
	}
}
