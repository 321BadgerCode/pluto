//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class pause:MonoBehaviour{
	[SerializeField]private GameObject pause_menu;

	private void Start(){
		Time.timeScale=1;
	}
	private void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			pause_menu.SetActive(!pause_menu.activeSelf);
			if(pause_menu.activeSelf==true){set_pause();}
			else{set_resume();}
		}
	}

	public void set_pause(){pause_menu.SetActive(true);Time.timeScale=0f;FindObjectOfType<cursor>().set_lockdown(false);}
	public void set_resume(){pause_menu.SetActive(false);Time.timeScale=1f;FindObjectOfType<cursor>().set_lockdown(true);}
	public void set_resume2(){pause_menu.SetActive(false);Time.timeScale=1f;}
};