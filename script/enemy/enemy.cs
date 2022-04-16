//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class enemy:MonoBehaviour{
	private BoxCollider bc;
	private Rigidbody rb;
	private GameObject player;

	[System.Serializable()]
	public class value_stat{
		public int hurt;
		public int death;
	}
	public health health2;
	public float damage=10;
	public value_stat value_stat2;

	private void Awake(){
		transform.tag="enemy";
	}
	private void Start(){
		player=GameObject.FindGameObjectWithTag("player");

		bc=gameObject.AddComponent<BoxCollider>();
		bc.isTrigger=true;

		rb=gameObject.AddComponent<Rigidbody>();
		rb.constraints=RigidbodyConstraints.FreezeRotation;
	}
	private void Update(){
		if(health2.health2<=0||get_is_off_map()==true||player.GetComponent<player>().is_dead==true){set_die();}
	}
	private void OnTriggerEnter(Collider c){
		if(c.tag=="player"||c.tag=="ally"){
			c.GetComponent<health>().set_add_value(-damage);
		}
	}
	private bool get_is_off_map(){
		bool b1=false;

		if(transform.position.y<=-50){b1=true;}
		else{b1=false;}

		return b1;
	}

	public void set_die(){Destroy(gameObject);StartCoroutine(FindObjectOfType<screen_shake_manager>().set_shake(1,3));}
}