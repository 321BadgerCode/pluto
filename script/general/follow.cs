//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class follow:MonoBehaviour{
	[SerializeField] private GameObject target;

	private void Update(){
		transform.position = target.transform.position;
	}
}