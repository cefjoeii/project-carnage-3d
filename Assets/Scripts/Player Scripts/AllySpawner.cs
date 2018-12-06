using UnityEngine;
using System.Collections;

//This code may be a bit long but we've fixed it for reusability :) So awesome! Cheers!
//We have four spawn points

public class AllySpawner : MonoBehaviour {

	public Transform spawningEffects;
	public GameObject Ally1,Ally2,Ally3;
	public enum AllyToSpawn { Ally1,Ally2,Ally3,All };
	public AllyToSpawn allyToSpawn;

	public int numberOfSpawns, spawnCount, counter = 0;
	private int locationSet = 1, randomNumber=0;
	public float startWait, spawnWait, waveWait;
	private float effectsWait = 3.0f;

	private Vector3 spawnPosition;
	private Quaternion spawnRotation;

	private float Ally1Y = 0.24f, Ally2Y = 0.24f, Ally3Y = 0.24f;
	private float AllyY; // All of the tanks' different Y positions are automajically altered here.
	public float AllyX1,AllyZ1,AllyX2,AllyZ2,AllyX3,AllyZ3,AllyX4,AllyZ4; 
	
	IEnumerator Start()
	{
		yield return new WaitForSeconds(startWait);
		StartCoroutine(SpawnTanks());
	}

	IEnumerator SpawnTanks()
	{
		while (counter<numberOfSpawns)
		{
			for (int i=0; i<spawnCount; i++)
			{
				if(counter >= numberOfSpawns) break;

				if(PowerUpsController.tanksCanMove)
				{
					if(allyToSpawn == AllyToSpawn.Ally1)
					{
						AllyY = Ally1Y;
						SpawnLocator();
						Instantiate(spawningEffects, spawnPosition, spawnRotation);
						yield return new WaitForSeconds(effectsWait);
						Instantiate(Ally1, spawnPosition, spawnRotation);
					}
					else if(allyToSpawn == AllyToSpawn.Ally2)
					{
						AllyY = Ally2Y;
						SpawnLocator();
						Instantiate(spawningEffects, spawnPosition, spawnRotation);
						yield return new WaitForSeconds(effectsWait);
						Instantiate(Ally2, spawnPosition, spawnRotation);
					}
					else if(allyToSpawn == AllyToSpawn.Ally3)
					{
						AllyY = Ally3Y;
						SpawnLocator();
						Instantiate(spawningEffects, spawnPosition, spawnRotation);
						yield return new WaitForSeconds(effectsWait);
						Instantiate(Ally3, spawnPosition, spawnRotation);
					}
					else if(allyToSpawn == AllyToSpawn.All)
					{
						randomNumber = Random.Range(1, 4);
						switch(randomNumber)
						{
						case 1:
							AllyY = Ally1Y;
							SpawnLocator();
							Instantiate(spawningEffects, spawnPosition, spawnRotation);
							yield return new WaitForSeconds(effectsWait);
							Instantiate(Ally1, spawnPosition, spawnRotation);
							break;
						case 2:
							AllyY = Ally2Y;
							SpawnLocator();
							Instantiate(spawningEffects, spawnPosition, spawnRotation);
							yield return new WaitForSeconds(effectsWait);
							Instantiate(Ally2, spawnPosition, spawnRotation);
							break;
						case 3:
							AllyY = Ally3Y;
							SpawnLocator();
							Instantiate(spawningEffects, spawnPosition, spawnRotation);
							yield return new WaitForSeconds(effectsWait);
							Instantiate(Ally3, spawnPosition, spawnRotation);
							break;
						}
					}
					counter++;
					yield return new WaitForSeconds (spawnWait);
				}//end of if tanksCanMove
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
		
	void SpawnLocator()
	{
		Quaternion spawnRotation1 = new Quaternion (0, 180, 0,0);
		Vector3 spawnPosition1 = new Vector3(AllyX1, AllyY, AllyZ1);
		Quaternion spawnRotation2 = new Quaternion (0, 180, 0,0);
		Vector3 spawnPosition2 = new Vector3(AllyX2, AllyY, AllyZ2);
		Quaternion spawnRotation3 = new Quaternion (0, 0, 0,0);
		Vector3 spawnPosition3 = new Vector3(AllyX3, AllyY, AllyZ3);
		Quaternion spawnRotation4 = new Quaternion (0, 0, 0,0);
		Vector3 spawnPosition4 = new Vector3(AllyX4, AllyY, AllyZ4);

		switch (locationSet)
		{
		case 1:
			spawnRotation = spawnRotation1;
			spawnPosition = spawnPosition1;
			locationSet++;
			break;
		case 2:
			spawnRotation = spawnRotation2;
			spawnPosition = spawnPosition2;
			locationSet++;
			break;
		case 3:
			spawnRotation = spawnRotation3;
			spawnPosition = spawnPosition3;
			locationSet++;
			break;
		case 4:
			spawnRotation = spawnRotation4;
			spawnPosition = spawnPosition4;
			locationSet++;
			break;
		}
		if (locationSet > 4)
		{ locationSet = 1; }
	}
}