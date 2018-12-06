using UnityEngine;
using System.Collections;

public class AiLife : MonoBehaviour {
	public int aiHealth = 1, points = 0;
	public Transform explosionPrefab, powerUpsSpeed, powerUpsInvulnerable, powerUpsStop, powerUpsEvolve, powerUpsBoom;
	public float shakeIntensityDead = .05f, shakeDecayDead = .0025f;
	private int probability = 0, powerUpsToSpawn = 0;
	
	void Update()
	{
		probability = Random.Range(1,3); // chance that a powerUp will appear
		powerUpsToSpawn = Random.Range(1,10);
	}
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "PlayerBullet")
		{
			aiHealth--;
			if(aiHealth<=0)
			{
				CameraShake.shakeIntensity = shakeIntensityDead;
				CameraShake.shakeDecay = shakeDecayDead;
				GameObject.FindWithTag("MainCamera").SendMessage("DoShake");
				Instantiate(explosionPrefab, gameObject.transform.localPosition, gameObject.transform.localRotation);
				Score.currentScore += points;
				SpawnPowerUps();
				//If there is a ResultShow GameObject in the scene, killcounter++
				if(GameObject.Find("ResultShow")) { GameObject.Find("ResultShow").GetComponent<ResultShow>().killCounter++; }
				Destroy(gameObject);
			}
		}
		if(other.gameObject.tag == "BoomPanes")
		{
			aiHealth -= 5;
			if(aiHealth<=0)
			{
				Instantiate(explosionPrefab, gameObject.transform.localPosition, gameObject.transform.localRotation);
				Score.currentScore += points;
				//If there is a ResultShow GameObject in the scene, killcounter++
				if(GameObject.Find("ResultShow")) { GameObject.Find("ResultShow").GetComponent<ResultShow>().killCounter++; }
				Destroy(gameObject);
			}
		}
	}

	void SpawnPowerUps()
	{
		if(probability == 1 && PowerUpsController.isPowerUpsEnabledStatic)
		{
			if(PowerUpsController.powerUpsReady)
			{
				//powerUpsToSpawn = 5; // For Debugging Purposes
				switch(powerUpsToSpawn)
				{
				case 1:
					Instantiate(powerUpsSpeed, new Vector3(transform.localPosition.x,0.5217577f,transform.localPosition.z), transform.localRotation);
					break;
				case 3:
					Instantiate(powerUpsStop, new Vector3(transform.localPosition.x,0.5217577f,transform.localPosition.z), transform.localRotation);
					break;
				case 5:
					Instantiate(powerUpsInvulnerable, new Vector3(transform.localPosition.x,0.5217577f,transform.localPosition.z), transform.localRotation);
					break;
				case 7:
					Instantiate(powerUpsEvolve, new Vector3(transform.localPosition.x,0.5217577f,transform.localPosition.z), transform.localRotation);
					break;
				case 9:
					Instantiate(powerUpsBoom, new Vector3(transform.localPosition.x,0.5217577f,transform.localPosition.z), transform.localRotation);
					break;
				default:
					break;
				}
			}
		}
	}
}
