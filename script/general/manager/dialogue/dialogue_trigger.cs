//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class dialogue_trigger:MonoBehaviour{
	public dialogue d1;

	public void set_trigger_dialogue(){
		FindObjectOfType<dialogue_manager>().set_start_dialogue(d1);
	}
}