using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance = null;

	public Sound[] sounds;

	Sound currentSound;

	void Awake()
    {
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}
	}

	void Start()
	{
		//Play("Theme");
	}
	
    public void Play(string name)
	{
		if (currentSound != null)
		{
			StartCoroutine(FadeOut(currentSound.source, 1.0f));
		}

		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + s + " not found!");
			return;
		}

		StartCoroutine(FadeIn(s.source, 1.0f));
		currentSound = s;
	}

	public void PlayAfterTime(string name, float time)
	{
		if (currentSound != null)
		{
			StartCoroutine(FadeOut(currentSound.source, 1.0f));
		}

		StartCoroutine(ExecuteAfterTime(name, time));
	}

	IEnumerator ExecuteAfterTime(string name, float time)
	{
		yield return new WaitForSeconds(time);

		Play(name);
	}

	public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
	{
		float startVolume = audioSource.volume;
		while (audioSource.volume > 0)
		{
			audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
			yield return null;
		}

		audioSource.Stop();
	}

	public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
	{
		float endVolume = audioSource.volume;
		audioSource.Play();
		audioSource.volume = 0f;
		while (audioSource.volume < endVolume)
		{
			audioSource.volume += Time.deltaTime / FadeTime;
			yield return null;
		}
	}
}
