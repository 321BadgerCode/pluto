//badger
using UnityEngine;

public sealed class cursor:MonoBehaviour{
	[SerializeField()]private bool is_locked=true;

	private void Start(){
		set_lock(is_locked);
	}

	public void set_lock(bool lock2){
		if(lock2==true){Cursor.lockState=CursorLockMode.Locked;Cursor.visible=false;}
		else{Cursor.lockState=CursorLockMode.None;Cursor.visible=true;}
	}
};