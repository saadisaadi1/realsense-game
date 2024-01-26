using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{ 

	[SerializeField]
	private Sound[] pool;         // A pool with a bunch of sounds and settings for said sounds

	// Play a sound from the pool
	public void Play(string name, Vector3 position)
	{
		Sound sound = Array.Find(pool,
			element => element.name == name);

		if (sound == null)
		{
			Debug.LogWarning("Sound: '" + name + "' couldn't be played because it wasn't found.");
			return;
		}

		GameObject new_sound = Instantiate(sound.prefab, position, Quaternion.identity);
		if (!sound.remain)
        {
			StartCoroutine(DestructionCoroutine(sound.duration, new_sound));
        }
	}
	public IEnumerator DestructionCoroutine(float duration, GameObject sound)
    {
		yield return new WaitForSeconds(duration);
		sound.GetComponent<DestroyScript>().DestroySound();
    }
}
