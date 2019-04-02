using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
	bool triggerEntered = false;
	Vector3 defaultScale;
	public GameObject grid;

	private void OnTriggerEnter(Collider other)
	{
		if (GetComponent<Collider>().isTrigger)
		{
			triggerEntered = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (GetComponent<Collider>().isTrigger)
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
			float scaleY = transform.localScale.y - 0.1f * Time.deltaTime;
			scaleY = Mathf.Max(scaleY, defaultScale.y * 0.1f);

			transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);

			if (grid)
			{
				grid.GetComponent<StartPathAnimation>().StartAnimation();
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
