using UnityEngine;
using System.Collections;

//This code may be a bit long but we've fixed it for reusability :) So awesome! Cheers!
//We have four spawn points

public class AiSpawner : MonoBehaviour {

	public Transform spawningEffects;
	public GameObject Ai1,Ai2,Ai3,Ai4,Ai5;
	public enum AiToSpawn { Ai1,Ai2,Ai3,Ai4,Ai5,All };
	public AiToSpawn aiToSpawn;

	public int numberOfSpawns, spawnCount, counter = 0;
	private int locationSet = 1, randomNumber = 0;
	public float startWait, spawnWait, waveWait;
	private float effectsWait = 3.0f;

	private Vector3 spawnPosition;
	private Quaternion spawnRotation;

	private float Ai1Y = 0.01237795f, Ai2Y = -0.00462532f, Ai3Y = 0.007843137f, Ai4Y = 0.01272297f, Ai5Y = 0.01166928f;
	private float AiY; // All of the tanks' different Y positions are automajically altered here.
	public float AiX1,AiZ1,AiX2,AiZ2,AiX3,AiZ3,AiX4,AiZ4; 
	
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
				if(aiToSpawn == AiToSpawn.Ai1)
				{
					AiY = Ai1Y;
					SpawnLocator();
					Instantiate(spawningEffects, spawnPosition, spawnRotation);
					yield return new WaitForSeconds(effectsWait);
					Instantiate(Ai1, spawnPosition, spawnRotation);
				}
				else if(aiToSpawn == AiToSpawn.Ai2)
				{
					AiY = Ai2Y;
					SpawnLocator();
					Instantiate(spawningEffects, spawnPosition, spawnRotation);
					yield return new WaitForSeconds(effectsWait);
					Instantiate(Ai2, spawnPosition, spawnRotation);
				}
				else if(aiToSpawn == AiToSpawn.Ai3)
				{
					AiY = Ai3Y;
					SpawnLocator();
					Instantiate(spawningEffects, spawnPosition, spawnRotation);
					yield return new WaitForSeconds(effectsWait);
					Instantiate(Ai3, spawnPosition, spawnRotation);
				}
				else if(aiToSpawn == AiToSpawn.Ai4)
				{
					AiY = Ai4Y;
					SpawnLocator();
					Instantiate(spawningEffects, spawnPosition, spawnRotation);
					yield return new WaitForSeconds(effectsWait);
					Instantiate(Ai4, spawnPosition, spawnRotation);
				}
				else if(aiToSpawn == AiToSpawn.Ai5)
				{
					AiY = Ai5Y;
					SpawnLocator();
					Instantiate(spawningEffects, spawnPosition, spawnRotation);
					yield return new WaitForSeconds(effectsWait);
					Instantiate(Ai5, spawnPosition, spawnRotation);
				}
				else if (aiToSpawn == AiToSpawn.All)
				{
					randomNumber = Random.Range(1, 6);
					switch(randomNumber)
					{
					case 1:
						AiY = Ai1Y;
						SpawnLocator();
						Instantiate(spawningEffects, spawnPosition, spawnRotation);
						yield return new WaitForSeconds(effectsWait);
						Instantiate(Ai1, spawnPosition, spawnRotation);
						break;
					case 2:
						AiY = Ai2Y;
						SpawnLocator();
						Instantiate(spawningEffects, spawnPosition, spawnRotation);
						yield return new WaitForSeconds(effectsWait);
						Instantiate(Ai2, spawnPosition, spawnRotation);
						break;
					case 3:
						AiY = Ai3Y;
						SpawnLocator();
						Instantiate(spawningEffects, spawnPosition, spawnRotation);
						yield return new WaitForSeconds(effectsWait);
						Instantiate(Ai3, spawnPosition, spawnRotation);
						break;
					case 4:
						AiY = Ai4Y;
						SpawnLocator();
						Instantiate(spawningEffects, spawnPosition, spawnRotation);
						yield return new WaitForSeconds(effectsWait);
						Instantiate(Ai4, spawnPosition, spawnRotation);
						break;
					case 5:
						AiY = Ai5Y;
						SpawnLocator();
						Instantiate(spawningEffects, spawnPosition, spawnRotation);
						yield return new WaitForSeconds(effectsWait);
						Instantiate(Ai5, spawnPosition, spawnRotation);
						break;
					}
				}
				counter++;
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}

	}
		
	void SpawnLocator()
	{
		Quaternion spawnRotation1 = new Quaternion (0, 180, 0,0);
		Vector3 spawnPosition1 = new Vector3(AiX1, AiY, AiZ1);
		Quaternion spawnRotation2 = new Quaternion (0, 180, 0,0);
		Vector3 spawnPosition2 = new Vector3(AiX2, AiY, AiZ2);
		Quaternion spawnRotation3 = new Quaternion (0, 0, 0,0);
		Vector3 spawnPosition3 = new Vector3(AiX3, AiY, AiZ3);
		Quaternion spawnRotation4 = new Quaternion (0, 0, 0,0);
		Vector3 spawnPosition4 = new Vector3(AiX4, AiY, AiZ4);

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