using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

	public int playerHealth = 1;
	public static int playerHealthStatic;
	public Transform explosionPrefab;
	public float shakeIntensityAlive = .1f, shakeDecayAlive = .004f;
	public float shakeIntensityDead = .2f, shakeDecayDead = .004f;
	public static bool killable = false;

	IEnumerator Start()
	{
		killable = false;
		InvulnerableEffect.enabled = true;
		yield return new WaitForSeconds(6);
		if(PowerUpsController.gotInvulnerability == false)
		{
			InvulnerableEffect.enabled = false;
			killable = true;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "EnemyBullet" && killable == true)
		{
			playerHealthStatic--;
			if(playerHealthStatic>0)
			{
				CameraShake.shakeIntensity = shakeIntensityAlive;
				CameraShake.shakeDecay = shakeDecayAlive;
				GameObject.FindWithTag("MainCamera").SendMessage("DoShake");
			}
			else if(playerHealthStatic<=0)
			{
				CameraShake.shakeIntensity = shakeIntensityDead;
				CameraShake.shakeDecay = shakeDecayDead;
				GameObject.FindWithTag("MainCamera").SendMessage("DoShake");
				Instantiate(explosionPrefab, gameObject.transform.localPosition, gameObject.transform.localRotation);

				PlayerSpawner.PlayerX = transform.localPosition.x;
				PlayerSpawner.PlayerZ = transform.localPosition.z;
				PlayerSpawner.playerToSpawn = PlayerSpawner.PlayerToSpawn.Player1;
				PlayerSpawner.spawnPlayerNow = true;
				PlayerSpawner.playerLife--;

				Destroy(gameObject);
			}
		}
	}
}
