//badger
using UnityEngine;

[CreateAssetMenu(fileName="melee_data",menuName="data/melee",order=2)]
public class melee_data:ScriptableObject{
	[HideInInspector()]public bool is_bought;

	public new string name;

	public GameObject prefab;

	public int damage;
	public float range;

	public int cost;

	public void set_attack(string target){
		Ray ray=FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);
		ray.origin=new Vector3(ray.origin.x,ray.origin.y,ray.origin.z+prefab.transform.localScale.z);

		if(Physics.Raycast(ray,out RaycastHit hit,range)){
			if(hit.transform.tag=="enemy"&&target=="enemy"){hit.transform.GetComponent<health>().set_add_value(-damage);PlayerPrefs.SetInt("coin",FindObjectOfType<player>().coin+=hit.transform.GetComponent<enemy>().value_stat2.hurt);FindObjectOfType<screen_shake_manager>().set_shake(.5f,.5f);}
			else if(hit.transform.tag=="player"&&target=="player"){hit.transform.GetComponent<health>().set_add_value(-damage);}
		}
	}
};