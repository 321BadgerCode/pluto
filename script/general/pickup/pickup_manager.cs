//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class pickup_manager:MonoBehaviour{
	private GameObject player2;

	private void Start(){
		player2=GameObject.FindWithTag("player");
	}

	public void set_player_health(){
		health h1=player2.GetComponent<health>();
		h1.health2=h1.max_health;
	}
	public void set_player_ammo(){
		gun_data gd1=player2.GetComponent<gun>().gun2;
		gd1.current_ammo=gd1.ammo;
	}
	public void set_player_coin(){
		int c1=PlayerPrefs.GetInt("coin");
		PlayerPrefs.SetInt("coin",c1+=1000);
	}
}