using UnityEngine;
using System.Collections;

public class PowerUpsEvolve : MonoBehaviour {

	public Transform powerUpsEffects, powerUpsEffects2;
	private int points = 500;

	IEnumerator Start()
	{
		PowerUpsController.powerUpsReady = false;
		yield return new WaitForSeconds(PowerUpsController.destroyTime);
		PowerUpsController.powerUpsReady = true;
		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision other)
	{
		Physics.IgnoreCollision(gameObject.collider, other.collider);

		if(other.gameObject.tag == "Player")
		{
			PlayerSpawner.PlayerX = transform.localPosition.x;
			PlayerSpawner.PlayerZ = transform.localPosition.z;
			if(PlayerSpawner.playerToSpawn != PlayerSpawner.PlayerToSpawn.Player3)
			{
				if(PlayerSpawner.playerToSpawn == PlayerSpawner.PlayerToSpawn.Player1)
				{ PlayerSpawner.playerToSpawn = PlayerSpawner.PlayerToSpawn.Player2; }
				else if(PlayerSpawner.playerToSpawn == PlayerSpawner.PlayerToSpawn.Player2)
				{ PlayerSpawner.playerToSpawn = PlayerSpawner.PlayerToSpawn.Player3; }

				PlayerSpawner.spawnPlayerNow = true;
				Destroy(other.gameObject);
				Instantiate(powerUpsEffects, transform.localPosition, transform.localRotation);
			}
			else if(PlayerSpawner.playerToSpawn == PlayerSpawner.PlayerToSpawn.Player3)
			{
				PlayerLife.playerHealthStatic = 3;
				Instantiate(powerUpsEffects2, transform.localPosition, transform.localRotation);
			}
			GameObject.Find("PowerUpsController").GetComponent<PowerUpsController>().Evolve();
			Score.currentScore += points;
			Destroy(gameObject);
		}
	}
}
