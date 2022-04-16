//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn:MonoBehaviour{
	private float start_time;
	private int enemy_length;

	[SerializeField()]private GameObject[] enemy;
	[SerializeField()]private float radius=100;
	[SerializeField()]private float drop_height=10;
	[SerializeField()]private float time_between_spawn=2;
	[SerializeField()]private int total_enemy_spawn=10;
	[SerializeField()]private int enemy_to_spawn=2;
	[SerializeField()]private int update_rate=20;

	private void Start(){
		start_time=Time.time;
		StartCoroutine(spawn());
	}
	private void Update(){
		if(Time.time-start_time>=update_rate){
			if(time_between_spawn>1){time_between_spawn--;}

			start_time=Time.time;
		}
	}
	private IEnumerator spawn(){
		while(enemy_length<total_enemy_spawn){
			for(int a=0;a<enemy_to_spawn;a++){
					Vector2 pos=Random.insideUnitCircle*radius;
					Instantiate(enemy[Random.Range(0,enemy.Length)],new Vector3(pos.x,drop_height,pos.y),Quaternion.identity);
					enemy_length++;
					yield return new WaitForSeconds(time_between_spawn);
			}
		}
	}
};