//badger
using UnityEngine;

public sealed class cursor:MonoBehaviour{
	[SerializeField()]private bool is_locked=true;
	[SerializeField()]private bool is_invisible=true;

	private void Start(){
		set_lock(is_locked);
		set_invisible(is_invisible);
	}

	public void set_lock(bool lock2){
		Cursor.lockState=lock2?CursorLockMode.Locked:CursorLockMode.None;
	}
	public void set_invisible(bool a1){
		Cursor.visible=!a1;
	}
	public void set_lockdown(bool lock2){
		Cursor.lockState=lock2?CursorLockMode.Locked:CursorLockMode.None;
		Cursor.visible=!lock2;
	}
};