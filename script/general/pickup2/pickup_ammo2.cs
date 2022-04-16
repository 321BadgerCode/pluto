//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_ammo2:pickup2{
	protected override void set_apply(){
		gun g1=GameObject.FindWithTag("player").GetComponent<gun>();
		gun_data gd1=g1.gun2;
		gd1.current_ammo=gd1.ammo;
		g1.set_text();
	}
}