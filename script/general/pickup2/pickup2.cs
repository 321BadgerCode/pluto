//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class pickup2:MonoBehaviour{
	private BoxCollider bc1;
	protected abstract void set_apply();

	private void Awake(){
		bc1=gameObject.AddComponent<BoxCollider>();
		bc1.isTrigger=true;
	}
	private void OnTriggerEnter(Collider c1){
		if(c1.tag=="player"){
			set_apply();
			Destroy(gameObject);
		}
	}
}