using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
	bool triggerEntered = false;
	Vector3 defaultScale;

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

	// Start is called before the first frame update
	void Awake()
    {
		defaultScale = transform.localScale;
	}

    // Update is called once per frame
    void Update()
    {
		if (triggerEntered)
		{
			float scaleY = transform.localScale.y - 0.1f * Time.deltaTime;
			scaleY = Mathf.Max(scaleY, defaultScale.y * 0.1f);

			transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);
		}
		else
		{
			float scaleY = transform.localScale.y + 0.1f * Time.deltaTime;
			scaleY = Mathf.Min(scaleY, defaultScale.y);

			transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);
		}
	}
}
