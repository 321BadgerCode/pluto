//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ally:MonoBehaviour{
	private player player2;
	private Rigidbody rb;
	private ally_move am;
	private health health2;

	public float damage;

	private void Awake(){
		transform.tag="ally";
	}
	private void Start(){
		player2=GameObject.FindGameObjectWithTag("player").GetComponent<player>();

		rb=gameObject.AddComponent<Rigidbody>();
		rb.constraints=RigidbodyConstraints.FreezeRotation;

		am=gameObject.AddComponent<ally_move>();
		am.speed=5;

		health2=gameObject.GetComponent<health>();
	}
	private void Update(){
		if(health2.health2<=0||get_is_off_map()==true||player2.is_dead==true){set_die();}
	}
	private void OnTriggerEnter(Collider c){
		if(c.tag=="enemy"){
			c.GetComponent<health>().set_add_value(-damage);
		}
	}
	private bool get_is_off_map(){
		bool b1=false;

		if(transform.position.y<=-50){b1=true;}
		else{b1=false;}

		return b1;
	}

	public void set_die(){Destroy(gameObject);}
}