//badger
using UnityEngine;

public class rotation:MonoBehaviour{
	[SerializeField][Range(1,100)] float sens=50f;

	private float mouseX, mouseY, rotationX, rotationY;
	private float multiplier = 0.1f;

	private void Start(){
		if(PlayerPrefs.GetFloat("sensitivity")!=0){sens=PlayerPrefs.GetFloat("sensitivity");}
	}

	private void Update()
	{
		input();

		transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
	}

	private void input()
	{
		mouseX = Input.GetAxisRaw("Mouse X");
		mouseY = Input.GetAxisRaw("Mouse Y");

		rotationY += mouseX * multiplier * sens;
		rotationX -= mouseY * multiplier * sens;

		rotationX = Mathf.Clamp(rotationX, -90f, 90f);
	}
};