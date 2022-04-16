//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class dialogue_manager:MonoBehaviour{
	private Queue<string> sentence;

	public TextMeshProUGUI name;
	public TextMeshProUGUI content;
	public float speed;
	public Animator anim;

	private void Start(){
		sentence=new Queue<string>();
	}
	private IEnumerator set_type_sentence(string sentence,float second){
		content.text="";

		foreach(char a in sentence.ToCharArray()){
			content.text+=a;
			yield return new WaitForSeconds(second);
		}
	}

	public void set_start_dialogue(dialogue a1){
		anim.SetBool("is_open",true);

		name.text=a1.name;

		sentence.Clear();

		foreach(string a in a1.sentence){
			sentence.Enqueue(a);
		}

		set_next_sentence();
	}
	public void set_next_sentence(){
		if(sentence.Count==0){
			set_end_dialogue();
			return;
		}
		string b1=sentence.Dequeue();
		StopAllCoroutines();
		StartCoroutine(set_type_sentence(b1,speed));
	}
	public void set_end_dialogue(){
		anim.SetBool("is_open",false);
	}
}