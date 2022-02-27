//badger
using UnityEngine;

public class player_move:MonoBehaviour{
	[SerializeField] private float speed = 50f;
	[SerializeField] private float rb_drag = 1f;
	[SerializeField] private float jump_force = 5f;

	private Rigidbody rb;
	private float movement_x, movement_y;
	private Vector3 move_dir;
	private bool is_grounded;

	private void Awake()
	{
		rb = gameObject.AddComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationY|RigidbodyConstraints.FreezeRotationZ;
	}

	private void Update()
	{
		is_grounded = rb.velocity.y == 0;
		input();
	}

	private void FixedUpdate()
	{
		move();
		jump();
	}

	private void input()
	{
		movement_x = Input.GetAxisRaw("Horizontal");
		movement_y = Input.GetAxisRaw("Vertical");
		move_dir = transform.forward * movement_y + transform.right * movement_x;
	}

	private void move()
	{
		rb.AddForce(move_dir.normalized * speed, ForceMode.Acceleration);
	}

	private void jump()
	{
		if (is_grounded)
		{
			if (Input.GetKey(KeyCode.Space))
			{
				rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
				rb.drag = 0f;
			}
			else rb.drag = rb_drag;
		}
	}
};
//fix input not working randomly
//fix jump not working(too high,etc.)

//add audio
//add enemy
//add guns,shooting,etc.
//post processing

//start manager script that takes actions like button and runs them when scene starts