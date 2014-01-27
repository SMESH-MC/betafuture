@script RequireComponent(CharacterController)

private var controller : CharacterController;
private var dir : Vector3 = Vector3.zero;
var speed : float = 6;
var gravity : float = 9.81;
var jumpPower : float = 5;
var airControl : float = 15;

function Awake () {
	controller = GetComponent(CharacterController);
}

function Update () {
	if(controller.isGrounded){
		dir.x = Input.GetAxis("Horizontal") * speed;
		if(Input.GetButtonDown("Jump")){
			dir.y = jumpPower;
		}
	}
	else {
		dir.y = dir.y - gravity;
		dir.x = (Input.GetAxis("Horizontal") * speed );
	}
	controller.Move(dir * Time.deltaTime);
}