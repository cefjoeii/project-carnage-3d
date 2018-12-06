using UnityEngine;
using System.Collections;

public class AiShoot : MonoBehaviour {

	public Rigidbody missile;
	public float shootForce = 500;
	private AudioSource audioSource;
	public float shootingTime = 2;
	public float _shootingTimer = 1;
	
	void Start ()
	{
		audioSource = (AudioSource)gameObject.AddComponent("AudioSource");
		audioSource.clip = (AudioClip)Resources.Load("tankfiring");
		audioSource.loop = false;
	}

	void Update () {
		_shootingTimer -= Time.deltaTime;
		Transform shootPosition = transform;
		if (_shootingTimer <= 0)
		{
			_shootingTimer = shootingTime;
			if(PowerUpsController.tanksCanMove)
			{
				Rigidbody instanceMissile = Instantiate(missile, transform.position, shootPosition.rotation)as Rigidbody;
				instanceMissile.rigidbody.AddForce(shootPosition.forward * shootForce);
				audioSource.Play();
			}
		}
	}
}
