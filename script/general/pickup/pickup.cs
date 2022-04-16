//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class pickup:MonoBehaviour{
	[SerializeField()]private pickup_data pd1;

	private void OnTriggerEnter(Collider c1){
		if(c1.tag=="player"){
			pd1.ue1.Invoke();
		}
	}
}