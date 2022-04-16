//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ally_move:MonoBehaviour{
	private Transform enemy;
	private Transform[] enemy_total;

	public float speed;

	private void Update(){
		if(enemy!=null){StartCoroutine(set_attack(enemy));}
		else{enemy=get_closest_enemy(transform,enemy_total);}
	}
	private void FixedUpdate(){
		GameObject[] go=GameObject.FindGameObjectsWithTag("enemy");
		System.Array.Resize(ref enemy_total,go.Length);
		for(int a=0;a<go.Length;a++){enemy_total[a]=go[a].transform;}
	}
	private IEnumerator set_attack(Transform enemy2){
		set_move_to(enemy2);
		yield return new WaitForSeconds(1);
	}
	private void set_move_to(Transform enemy2){
		transform.rotation=Quaternion.RotateTowards(transform.rotation,enemy.transform.rotation,speed*Time.deltaTime);
		transform.position=Vector3.MoveTowards(transform.position,enemy.transform.position,speed*Time.deltaTime);
	}

	public Transform get_closest_enemy(Transform from,Transform[] enemy2){
		Transform closest_enemy=null;
		float closest_distance_sqr=Mathf.Infinity;
		Vector3 current_pos=from.position;

		foreach(Transform target in enemy2){
			Vector3 target_dir=target.position-current_pos;
			float target_d_sqr=target_dir.sqrMagnitude;
			if(target_d_sqr<closest_distance_sqr){
				closest_distance_sqr=target_d_sqr;
				closest_enemy=target;
			}
		}

		return closest_enemy;
	}
}