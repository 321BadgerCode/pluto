//badger
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public sealed class setting_manager:MonoBehaviour{
	[SerializeField()]private TextMeshProUGUI if2;
	[SerializeField()]private AudioMixer song_audio_mixer;
	[SerializeField()]private AudioMixer effect_audio_mixer;

	private void Start(){
		if(PlayerPrefs.GetFloat("sensitivity")!=0){if2.text=PlayerPrefs.GetFloat("sensitivity").ToString();}
	}

	public void set_sensitivity(string a1){
		float sensitivity=float.Parse(a1);
		if(sensitivity>=1&&sensitivity<=100){PlayerPrefs.SetFloat("sensitivity",sensitivity);}
	}
	public void set_song_volume(float volume){song_audio_mixer.SetFloat("volume",volume);}
	public void set_effect_volume(float volume){effect_audio_mixer.SetFloat("volume",volume);}
};