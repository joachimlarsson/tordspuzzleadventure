using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishElevatorTrigger : MonoBehaviour
{
	bool triggerEntered = false;
	Vector3 defaultScale;
	bool triggerOnce = false;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("FinishElevatorTrigger OnTriggerEnter");
		if (this.gameObject.GetComponent<Collider>().isTrigger)
		{
			triggerEntered = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (this.gameObject.GetComponent<Collider>().isTrigger)
		{
			triggerEntered = false;
		}
	}

	void Awake()
    {
		defaultScale = transform.localScale;
	}

	void Update()
	{
		if (triggerEntered)
		{
			float lowestScaleY = defaultScale.y * 0.1f;

			if (Mathf.Approximately(transform.localScale.y, lowestScaleY) && !triggerOnce)
			{
				Debug.Log("Call start elevator");
				gameObject.GetComponentInParent<FinishElevatorMovementStart>().StartElevator();
				triggerOnce = true;
			}
			else
			{
				float scaleY = transform.localScale.y - 0.1f * Time.deltaTime;
				scaleY = Mathf.Max(scaleY, lowestScaleY);

				transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);
			}
		}
		else
		{
			float scaleY = transform.localScale.y + 0.1f * Time.deltaTime;
			scaleY = Mathf.Min(scaleY, defaultScale.y);

			transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);
		}
	}
}
