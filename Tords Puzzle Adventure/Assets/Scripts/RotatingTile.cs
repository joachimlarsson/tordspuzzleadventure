using UnityEngine;

public class RotatingTile : MonoBehaviour
{
	bool triggerEntered = false;
	public float rotationSpeed = 1.0f;
	float rotateTime = 0.0f;
	public float maxRotateTime = 2.0f;

	float animationTime = 0.0f;
	public float maxAnimationTime = 2.0f;
	bool showAnimation = false;
	float endAnimationTime = 0.0f;
	Quaternion defaultRotation;

	public void StartPathAnimation()
	{
		showAnimation = true;
	}

	void PlayAnimation()
	{
		animationTime += Time.deltaTime;
		if (animationTime < maxAnimationTime)
		{
			Transform par = transform.parent.transform;
			transform.RotateAround(transform.position, par.right, Random.Range(100.0f, 500.0f) * Time.deltaTime);
		}
		else
		{
			if (transform.rotation == defaultRotation)
				showAnimation = false;
			else
			{
				endAnimationTime += Time.deltaTime;
				transform.rotation = Quaternion.Lerp(transform.rotation, defaultRotation, endAnimationTime);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (this.gameObject.GetComponent<Collider>().isTrigger)
			triggerEntered = true;
	}

	void Awake()
	{
		defaultRotation = transform.rotation;
	}

	void Update()
	{
		if (triggerEntered)
		{
			rotateTime += Time.deltaTime;
			if (rotateTime > maxRotateTime)
			{
				rotationSpeed -= 0.005f * rotationSpeed;
			}

			transform.RotateAround(transform.position, transform.parent.transform.right, Mathf.Max(rotationSpeed, 0.0f) * Time.deltaTime);
		}

		if (this.gameObject.GetComponent<Collider>().isTrigger && showAnimation)
			PlayAnimation();
	}
}
