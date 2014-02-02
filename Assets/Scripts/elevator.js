#pragma strict

var amplitude: float = 5;
var speed: float = 0.2;
var direction: Vector3 = Vector3.up; 
private var p0: Vector3;
 
function Start()
{
	p0 = transform.position;
	while (true)
	{
		var dir = transform.TransformDirection(direction);
		transform.position = p0+amplitude*dir*Mathf.Sin(6.28*speed*Time.time);
		yield;
	}
}