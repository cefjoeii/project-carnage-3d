using UnityEngine;
using System.Collections;

//This code is for spawning the Player when it dies.
//Hardwork >= Talent

public class PlayerSpawner : MonoBehaviour {

	public Transform spawningEffects;
	public GameObject Player1, Player2, Player3;
	public enum PlayerToSpawn { Player1, Player2, Player3 };
	public static PlayerToSpawn playerToSpawn;
	public static bool spawnPlayerNow = false;
	public static int playerLife = 2;
	public float effectsWait;
	private float spawnWait;

	private Vector3 spawnPosition;
	private Quaternion spawnRotation;

	private float Player1Y = 0.24f, Player2Y = 0.24f, Player3Y = 0.24f;
	private float PlayerY; // All of the tanks' different Y positions are automajically altered here.
	public float beginningPlayerX,beginningPlayerZ;
	public static float PlayerX,PlayerZ;
	
	void Start()
	{
		PlayerX = beginningPlayerX; PlayerZ = beginningPlayerZ;
		spawnWait = 0;
		playerLife++;
		StartCoroutine(SpawnTanks());
	}

	void Update()
	{
		if(playerLife > 0 && spawnPlayerNow)
		{
			spawnWait = 3;
			StartCoroutine(SpawnTanks());
			spawnPlayerNow = false;
		}
	}

	IEnumerator SpawnTanks()
	{
		yield return new WaitForSeconds(spawnWait);

		//these depend upon the PowerUpsEvolve
		if(playerToSpawn == PlayerToSpawn.Player1)
		{
			PlayerY = Player1Y;
			SpawnLocator();
			Instantiate(spawningEffects, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(effectsWait);
			Instantiate(Player1, spawnPosition, spawnRotation);
			PlayerLife.playerHealthStatic = 1;
		}
		else if(playerToSpawn == PlayerToSpawn.Player2)
		{
			PlayerY = Player2Y;
			SpawnLocator();
			Instantiate(spawningEffects, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(effectsWait);
			Instantiate(Player2, spawnPosition, spawnRotation);
			PlayerLife.playerHealthStatic = 2;
		}
		else if(playerToSpawn == PlayerToSpawn.Player3)
		{
			PlayerY = Player3Y;
			SpawnLocator();
			Instantiate(spawningEffects, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(effectsWait);
			Instantiate(Player3, spawnPosition, spawnRotation);
			PlayerLife.playerHealthStatic = 3;
		}
	}

	void SpawnLocator()
	{
		spawnRotation = new Quaternion (0, 0, 0,0);
		spawnPosition = new Vector3(PlayerX, PlayerY, PlayerZ);
	}
}