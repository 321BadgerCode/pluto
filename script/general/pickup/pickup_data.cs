//badger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName="pickup_data",menuName="data/pickup",order=3)]
public class pickup_data:ScriptableObject{
	public new string name;

	public GameObject go1;

	public UnityEvent ue1;
}