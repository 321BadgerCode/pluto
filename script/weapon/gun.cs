//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class gun:MonoBehaviour{
	private bool is_reload;
	private float last_fire;

	public gun_data gun2;
	[SerializeField()]private TextMeshProUGUI ammo_text;

	public void set_text(){
		ammo_text.text=gun2.current_mag_size.ToString()+"/"+gun2.current_ammo.ToString();
	}

	private void Awake(){
		if(shop.gd_equip!=null){gun2=shop.gd_equip;}

		GameObject go1=Instantiate(gun2.prefab,transform.position+gun2.offset,transform.rotation);
		go1.transform.parent=gameObject.transform;
	}
	private void Start(){
		gun2.set_value();
		set_text();
	}
	private void Update(){
		if(is_reload==false){
			if(Input.GetKeyDown(KeyCode.Mouse0)&&gun2.fire_rate==0||Input.GetKey(KeyCode.Mouse0)&&gun2.fire_rate>0){
				set_shoot();
			}
			else if(Input.GetKeyDown(KeyCode.R)){
				if(gun2.current_ammo>0){StartCoroutine(set_reload());}
			}
		}
	}
	private void set_shoot(){
		if(gun2.current_mag_size>0){
			if(gun2.fire_rate>0&&Time.time-last_fire>1/gun2.fire_rate){last_fire=Time.time;gun2.set_shoot("enemy");}
			else{gun2.set_shoot("enemy");}
		}

		if(gun2.current_mag_size==0&&gun2.current_ammo>0){StartCoroutine(set_reload());}
		else{set_text();}
	}
	private IEnumerator set_reload(){
		is_reload=true;

		ammo_text.text="reloading...";

		yield return new WaitForSeconds(gun2.reload);

		gun2.current_ammo-=(gun2.mag_size-gun2.current_mag_size);
		if(gun2.current_ammo>=gun2.mag_size){gun2.current_mag_size=gun2.mag_size;}
		else{gun2.current_mag_size=gun2.current_ammo;}

		set_text();

		is_reload=false;
	}
}