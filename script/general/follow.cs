//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class follow:MonoBehaviour{
	[SerializeField] private Transform target;
	[SerializeField] private float smooth_speed=.125f;
	[SerializeField] private Vector3 offset;

	private void FixedUpdate(){
		Vector3 pos=target.position+offset;
		Vector3 smooth_pos=Vector3.Lerp(transform.position,pos,smooth_speed*Time.deltaTime);
		transform.position=smooth_pos;
	}
};