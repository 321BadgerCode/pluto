//badger
using UnityEngine;

public class player_move:MonoBehaviour{
	private Rigidbody rb;
	private CapsuleCollider cc;
	private float movement_x, movement_y;
	private Vector3 move_dir;
	private bool is_grounded;
	private bool collide_platform;

	[SerializeField] private float speed = 50f;
	[SerializeField] private float rb_drag = 1f;
	[SerializeField] private float jump_force = 5f;

	private void Awake(){
		rb = gameObject.AddComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationY|RigidbodyConstraints.FreezeRotationZ;

		cc=gameObject.AddComponent<CapsuleCollider>();
		cc.isTrigger=true;
	}

	private void Update(){
		is_grounded=(rb.velocity.y==0&&collide_platform==true);
		input();
	}

	private void FixedUpdate(){
		move();
		jump();
	}

	private void input(){
		movement_x=Input.GetAxisRaw("Horizontal");
		movement_y=Input.GetAxisRaw("Vertical");
		move_dir=(transform.forward*movement_y)+(transform.right*movement_x);
	}

	private void move(){
		rb.AddForce(move_dir.normalized*speed,ForceMode.Acceleration);
	}

	private void jump(){
		if(is_grounded==true){
			if(Input.GetKey(KeyCode.Space)){
				rb.AddForce(Vector3.up*jump_force,ForceMode.Impulse);
				rb.drag=rb_drag/2;
			}
			else{rb.drag=rb_drag;}
		}
	}
	private void OnTriggerEnter(Collider a1){
		if(a1.transform.tag=="platform"){collide_platform=true;}
	}
	private void OnTriggerExit(Collider a1){
		if(a1.transform.tag=="platform"){collide_platform=false;}
	}
};