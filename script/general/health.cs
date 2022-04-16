//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public sealed class health:MonoBehaviour{
	private float lerp_speed;

	[SerializeField()]private TextMeshProUGUI health_text;
	[SerializeField()]private Image health_bar;
	[SerializeField()]private bool regenerate_health;
	public float health2,max_health=100;

	private IEnumerator reload_health(){
		while(true){
			yield return new WaitForSeconds(3);
			if(health2<=max_health-5){set_add_value(5);}
		}
	}
	private void Start(){
		if(regenerate_health==true){StartCoroutine(reload_health());}
	}
	private void Update(){
		health_text.text=health2.ToString()+"%";
		if(health2>max_health){health2=max_health;}

		lerp_speed=3*Time.deltaTime;

		set_health_bar_fill();
		set_change_color();
	}
	private void set_health_bar_fill(){
		health_bar.fillAmount=Mathf.Lerp(health_bar.fillAmount,health2/max_health,lerp_speed);
	}
	private void set_change_color(){
		Color health_color=Color.Lerp(Color.red,Color.green,health2/max_health);

		health_bar.color=health_color;
	}

	public void set_add_value(float value){
		health2+=value;
	}
}