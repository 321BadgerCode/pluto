//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class screen_shake_manager:MonoBehaviour{
	private Transform camera2;

	private void Start(){
		camera2=GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
	}

	public IEnumerator set_shake(float duration,float magnitude){
		Vector3 original_pos=camera2.localPosition;
		float elapse=0;

		while(elapse<duration){
			float x=original_pos.x+Random.Range(-1,1)*magnitude;
			float y=original_pos.y+Random.Range(-1,1)*magnitude;
			Vector3 pos=new Vector3(x,y,original_pos.z);
			Vector3 smooth_pos=Vector3.Lerp(original_pos,pos,Time.deltaTime);

			camera2.localPosition=smooth_pos;

			elapse+=Time.deltaTime;

			yield return null;
		}
		camera2.localPosition=original_pos;
	}
}