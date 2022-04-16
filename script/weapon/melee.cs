//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class melee:MonoBehaviour{
	public melee_data melee2;
	public Vector3 offset;

	private void Awake(){
		GameObject go=Instantiate(melee2.prefab,transform.position+offset,transform.rotation);
		go.transform.parent=gameObject.transform;
	}
	private void Update(){
		if(Input.GetKeyDown(KeyCode.Mouse1)){
			melee2.set_attack("enemy");
		}
	}
};