using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public bool isShaking = false; 
	public static float shakeIntensity = 0, shakeDecay = 0;
	private Vector3 originalPosition;
	private Quaternion originalRotation;
	
	void Start()
	{
		isShaking = false;
		shakeIntensity = 0; shakeDecay = 0;
	}

	void Update ()
	{
		if(shakeIntensity > 0)
		{
			transform.position = originalPosition + Random.insideUnitSphere * shakeIntensity;
			transform.rotation = new Quaternion(originalRotation.x + Random.Range(-shakeIntensity, shakeIntensity)*.1f,
			                                    originalRotation.y + Random.Range(-shakeIntensity, shakeIntensity)*.1f,
			                                    originalRotation.z + Random.Range(-shakeIntensity, shakeIntensity)*.1f,
			                                    originalRotation.w + Random.Range(-shakeIntensity, shakeIntensity)*.1f);
			shakeIntensity -= shakeDecay;
		}
		else if (isShaking)
		{
			isShaking = false;  
		}
	}

	void DoShake()
	{
		originalPosition = transform.position;
		originalRotation = transform.rotation;
		isShaking = true;
	}  
}
