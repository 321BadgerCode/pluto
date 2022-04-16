//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audio_manager:MonoBehaviour{
	[System.Serializable()]
	public class sound{
		public string name;
		public AudioClip audio;
		[Range(0f,1f)] public float volume;
		[Range(.1f,3f)] public float pitch;
		[HideInInspector] public AudioSource source;
	}
	public sound[] sound2;

	void Awake(){
		foreach(sound s in sound2){
			s.source=gameObject.AddComponent<AudioSource>();
			s.source.clip=s.audio;
			s.source.volume=s.volume;
			s.source.pitch=s.pitch;
		}
	}

	public void play(string a1){sound s=System.Array.Find(sound2,sound=>sound.name==a1);s.source.Play();}
};