//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public sealed class scene_manager:MonoBehaviour{
	[System.Serializable()]
	public class scene
	{
		public string name;
		public LoadSceneMode lsm;
		public bool start=false;
	};

	[Header("scene class")]
	[Space(5)]
	[SerializeField()] private scene[] s1;

	public Animator anim;

	private void Start(){
		Time.timeScale=1;

		if(anim!=null){anim.SetTrigger("fade_in");}

		for(int a=0;a<s1.Length;a++){
			if(s1[a].start){
				SceneManager.LoadScene(s1[a].name,s1[a].lsm);
			}
		}
	}
	private IEnumerator set_scene_wait(string a1,int second){SceneManager.LoadSceneAsync(a1);yield return new WaitForSeconds(second);}
	private IEnumerator set_scene_fade(string scene,float second){
		Time.timeScale=0;
		anim.SetTrigger("fade_out");
		yield return new WaitForSecondsRealtime(second);
		SceneManager.LoadScene(scene);
	}

	public void get_scene(int a1)
	{
		try{SceneManager.LoadSceneAsync(s1[a1].name,s1[a1].lsm);}
		catch{}
	}
	public void set_scene(string a1) { try { SceneManager.LoadSceneAsync(a1); } catch (System.Exception a) { Debug.Log(a.ToString()); } }
	public void set_scene_wait2(string a1){StartCoroutine(set_scene_wait(a1,1));}
	public void set_scene_fade2(string scene){StartCoroutine(set_scene_fade(scene,0));}
};