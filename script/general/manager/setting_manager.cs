//badger
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public sealed class setting_manager:MonoBehaviour{
	private float volume;
	private bool is_mute;

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
	public void set_song_volume(float a1){if(is_mute==false){song_audio_mixer.SetFloat("volume",a1);}song_audio_mixer.GetFloat("volume",out volume);}
	public void set_effect_volume(float a1){effect_audio_mixer.SetFloat("volume",a1);}
	public void set_mute(bool a1){
		is_mute=a1;
		song_audio_mixer.SetFloat("volume",a1?-80:volume);
		effect_audio_mixer.SetFloat("volume",a1?-80:volume);
	}
	public void set_fullscreen(bool a1){Screen.fullScreen=a1;}
	public void set_quality(int a1){QualitySettings.SetQualityLevel(a1);}
	public void set_vsync(bool a1){QualitySettings.vSyncCount=a1?1:0;}
	public void set_antialiasing(int a1){QualitySettings.antiAliasing=a1;}
}