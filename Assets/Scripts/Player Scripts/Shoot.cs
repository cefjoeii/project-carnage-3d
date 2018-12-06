using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public Rigidbody missile;
	public float shootForce = 500;
	public float shootingInterval = 1;
	private float IntervalTimer = 1;
	private AudioSource audioSource;

	void Start ()
	{
		audioSource = (AudioSource)gameObject.AddComponent("AudioSource");
		audioSource.clip = (AudioClip)Resources.Load("tankfiring");
		audioSource.loop = false;
	}

	void Update()
	{
		Transform shootPosition = transform;
		if (Input.GetButtonDown("Jump") && GUIHolderLevels.pauseHolder.activeSelf == false)
		{
			if(IntervalTimer >= shootingInterval)
			{
				IntervalTimer=0;
				Rigidbody instanceMissile = Instantiate(missile, transform.position, shootPosition.rotation)as Rigidbody;
				instanceMissile.rigidbody.AddForce(shootPosition.forward * shootForce);
				audioSource.Play();
			}
		}
		IntervalTimer += Time.deltaTime;
	}

}
