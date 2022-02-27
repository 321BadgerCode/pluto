//badger
using UnityEngine;

[CreateAssetMenu(fileName = "gun_data", menuName = "data/gun", order = 1)]
public class gun:ScriptableObject{
	public new string name;
	public int damage;
	public float fire_rate;
	public float spread;
};