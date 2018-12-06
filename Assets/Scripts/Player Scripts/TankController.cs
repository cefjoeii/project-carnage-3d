using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
	
	public enum goDirection{ up, down, left, right, stay};
	public goDirection direction;
	public float speed;
	public static float realSpeed, originalSpeed;
	Quaternion initialRot;

	void Start () 
	{
		initialRot = transform.rotation;
		realSpeed = speed;
		originalSpeed = speed;
	}

	void Update()
	{
		rigidbody.velocity = Vector3.zero; 
		if (direction == goDirection.right)
		{
			transform.rotation = initialRot;
			transform.Rotate(new Vector3(0, 90, 0));
			rigidbody.AddForce(transform.forward * realSpeed, ForceMode.Impulse);
		}
		else if (direction == goDirection.left)
		{
			transform.rotation = initialRot;
			transform.Rotate(new Vector3(0, -90, 0));
			rigidbody.AddForce(transform.forward * realSpeed, ForceMode.Impulse);
		}
		else if (direction == goDirection.up)
		{
			transform.rotation = initialRot;
			transform.Rotate(new Vector3(0, 0, 0));
			rigidbody.AddForce(transform.forward * realSpeed, ForceMode.Impulse);
		}
		else if (direction == goDirection.down)
		{
			transform.rotation = initialRot;
			transform.Rotate(new Vector3(0, 180, 0));
			rigidbody.AddForce(transform.forward * realSpeed, ForceMode.Impulse);
		}
	}
}
