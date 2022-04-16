//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public sealed class shop_manager:MonoBehaviour{
	private gun_data gd1;

	[SerializeField()]private TextMeshProUGUI coin;

	[SerializeField()]private Image prefab;
	[SerializeField()]private TextMeshProUGUI name;
	[SerializeField()]private TextMeshProUGUI damage;
	[SerializeField()]private TextMeshProUGUI range;
	[SerializeField()]private TextMeshProUGUI mag_size;
	[SerializeField()]private TextMeshProUGUI ammo;
	[SerializeField()]private TextMeshProUGUI price;
	[SerializeField()]private Button buy_button;
	[SerializeField()]private Dropdown equip_dropdown;

	public void Start(){
		coin.text="Coins: "+PlayerPrefs.GetInt("coin").ToString();
	}
	public void set_gun_stat(gun_data a1){
		gd1=a1;

		//prefab.Image.SourceImage=a1.prefab;
		name.text="name: "+a1.name;
		damage.text="damage: "+a1.damage.ToString();
		range.text="range: "+a1.range.ToString();
		mag_size.text="mag. size: "+a1.mag_size.ToString();
		ammo.text="ammo.: "+a1.ammo.ToString();
		price.text="price: "+a1.cost.ToString();
	}
	public void set_buy(){
		int b1=PlayerPrefs.GetInt("coin");
		if(b1>=gd1.cost&&PlayerPrefs.GetInt(gd1.name)==0){
			PlayerPrefs.SetInt(gd1.name,1);
			PlayerPrefs.SetInt("coin",b1-=gd1.cost);
			coin.text="Coins: "+PlayerPrefs.GetInt("coin").ToString();
		}
	}
	public void set_equip(){
		if(PlayerPrefs.GetInt(gd1.name)==1){shop.gd_equip=gd1;}
	}
}