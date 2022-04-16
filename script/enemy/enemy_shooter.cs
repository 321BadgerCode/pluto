//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class enemy_shooter:MonoBehaviour{
	public gun_data gun2;
	[SerializeField()]private Vector3 offset;

	private void Awake(){
		GameObject go=Instantiate(gun2.prefab,transform.position+offset,transform.rotation);
		go.transform.parent=gameObject.transform;
	}
	private void Update(){
		StartCoroutine(set_decide());
	}

	private IEnumerator set_decide(){
		int r1=Random.Range(0,2);

		if(r1==0){gun2.set_shoot("player");}
		else{yield return new WaitForSeconds(5);}
	}
}