//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class start_manager:MonoBehaviour{
	public void set_quit(){
		Application.Quit();
	}
	public void set_go_to_feedback_form(){
		Application.OpenURL("https://forms.gle/GtcHXEJvYA7wcFh86");
	}
}