//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_health2:pickup2{
	protected override void set_apply(){
		health h1=GameObject.FindWithTag("player").GetComponent<health>();
		h1.health2=h1.max_health;
	}
}