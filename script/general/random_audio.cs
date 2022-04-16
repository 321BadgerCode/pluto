//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_audio:MonoBehaviour{
	private AudioSource as1;

	[SerializeField()] private AudioClip[] audioClips;

	private void Awake(){as1=gameObject.AddComponent<AudioSource>();}

	public void play(){
		as1.clip=audioClips[Random.Range(0,audioClips.Length)];
		as1.PlayOneShot(as1.clip);
	}
};