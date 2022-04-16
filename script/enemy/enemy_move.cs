//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class enemy_move:MonoBehaviour{
	private GameObject player;

	[SerializeField()]private float speed=10;

	private void Start(){
		player=GameObject.FindWithTag("player");
	}
	private void Update(){
		transform.rotation=Quaternion.RotateTowards(transform.rotation,player.transform.rotation,speed*Time.deltaTime);
		transform.position=Vector3.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);
	}
};