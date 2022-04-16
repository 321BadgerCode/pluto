//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class pickup_spawn:MonoBehaviour{
	[SerializeField()]private pickup_data[] pd1;
	[SerializeField()]private float radius;
	[SerializeField()]private float time;
	[SerializeField()]private float height;

	private void Start(){
		StartCoroutine(set_spawn());
	}
	private IEnumerator set_spawn(){
		while(true){
			Instantiate(pd1[Random.Range(0,pd1.Length)].go1,get_pos(),Quaternion.identity);
			yield return new WaitForSeconds(time);
		}
	}
	private Vector3 get_pos(){
		Vector2 v1=Random.insideUnitCircle*radius;
		Vector3 v2=new Vector3(v1.x,height,v1.y);

		return v2;
	}
}