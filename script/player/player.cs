//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class player:MonoBehaviour{
	[HideInInspector()]public bool is_dead;
	[HideInInspector()]public int coin;

	[SerializeField()]private GameObject death_menu;
	[SerializeField()]private TextMeshProUGUI coin2;
	public health health2;

	private void Awake(){
		transform.tag="player";
	}
	private void Start(){
		coin=PlayerPrefs.GetInt("coin");
		PlayerPrefs.SetInt("coin",coin);
	}
	private void Update(){
		if(health2.health2<=0||get_is_off_map()==true){set_die();}

		coin=PlayerPrefs.GetInt("coin");
		coin2.text="Coins: "+coin.ToString();
	}
	private bool get_is_off_map(){
		bool b1=false;

		if(transform.position.y<=-50){b1=true;}
		else{b1=false;}

		return b1;
	}
	
	public void set_die(){is_dead=true;death_menu.SetActive(true);Time.timeScale=0;FindObjectOfType<cursor>().set_lockdown(false);}
}