//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	private void Start(){
		for(int a=0;a<s1.Length;a++){
			if(s1[a].start){
				SceneManager.LoadScene(s1[a].name,s1[a].lsm);
			}
		}
	}
	private IEnumerator set_scene_wait(string a1,int second){SceneManager.LoadSceneAsync(a1);yield return new WaitForSeconds(second);}

	public void get_scene(int a1)
	{
		try{SceneManager.LoadSceneAsync(s1[a1].name,s1[a1].lsm);}
		catch{}
	}
	public void set_scene(string a1) { try { SceneManager.LoadSceneAsync(a1); } catch (System.Exception a) { Debug.Log(a.ToString()); } }
	public void set_scene_wait2(string a1){StartCoroutine(set_scene_wait(a1,1));}
};