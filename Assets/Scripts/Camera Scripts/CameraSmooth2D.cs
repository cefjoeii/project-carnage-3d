using UnityEngine;
using System.Collections;

public class CameraSmooth2D : MonoBehaviour {
	
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public static Transform startingTarget, finalTarget;

	void Update () 
	{
		finalTarget = startingTarget;
		if (finalTarget)
		{
			Vector3 point = camera.WorldToViewportPoint(finalTarget.position);
			Vector3 delta = finalTarget.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
		
	}
}