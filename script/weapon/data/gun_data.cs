//badger
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName="gun_data",menuName="data/gun",order=1)]
public class gun_data:ScriptableObject{
	[HideInInspector()]public int current_mag_size;
	[HideInInspector()]public int current_ammo;

	public new string name;

	public GameObject prefab;
	public Image cross_hair;

	[System.Flags()]public enum type{none,burst,semi_auto,auto,everything};
	public type t1;

	public int damage;
	public float range;
	public float spread;
	public float fire_rate;

	public int mag_size;
	public int ammo;
	public float reload;

	public int cost;

	public Vector3 offset;

	public void set_value(){
		current_mag_size=mag_size;
		current_ammo=ammo-mag_size;
	}
	public void set_shoot(string target){
		Ray ray=FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);
		ray.origin=new Vector3(ray.origin.x,ray.origin.y,ray.origin.z+prefab.transform.localScale.z);

		if(Physics.Raycast(ray,out RaycastHit hit,range)){
			if(hit.transform.tag=="enemy"&&target=="enemy"){
				hit.transform.GetComponent<health>().set_add_value(-damage);
				PlayerPrefs.SetInt("coin",FindObjectOfType<player>().coin+=hit.transform.GetComponent<enemy>().value_stat2.hurt);
			}
			else if(hit.transform.tag=="player"&&target=="player"){
				hit.transform.GetComponent<health>().set_add_value(-damage);
			}
		}

		current_mag_size--;
	}
}