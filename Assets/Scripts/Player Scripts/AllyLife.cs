using UnityEngine;
using System.Collections;

public class AllyLife : MonoBehaviour {

	public int allyHealth = 1;
	public Transform explosionPrefab;
	public float shakeIntensityAlive = .1f, shakeDecayAlive = .004f;
	public float shakeIntensityDead = .2f, shakeDecayDead = .004f;
	public static bool gameOver=false;

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "EnemyBullet")
		{
			allyHealth--;
			if(allyHealth>0)
			{
				CameraShake.shakeIntensity = shakeIntensityAlive;
				CameraShake.shakeDecay = shakeDecayAlive;
				GameObject.FindWithTag("MainCamera").SendMessage("DoShake");
			}
			else if(allyHealth<=0)
			{
				CameraShake.shakeIntensity = shakeIntensityDead;
				CameraShake.shakeDecay = shakeDecayDead;
				GameObject.FindWithTag("MainCamera").SendMessage("DoShake");
				Instantiate(explosionPrefab, gameObject.transform.localPosition, gameObject.transform.localRotation);
				Destroy(gameObject);
			}
		}
	}
}
