//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class dont_destroy_on_load:MonoBehaviour{
	private void Awake(){DontDestroyOnLoad(gameObject);}
}