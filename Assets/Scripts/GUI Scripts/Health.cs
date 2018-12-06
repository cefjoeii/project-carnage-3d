using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public Texture2D health0, health1, health2, health3;

	void Start()
	{
		PlayerLife.playerHealthStatic = 0;
		guiTexture.texture = health0;
	}

	void Update()
	{
		if(PlayerSpawner.playerToSpawn == PlayerSpawner.PlayerToSpawn.Player1)
		{
			switch(PlayerLife.playerHealthStatic)
			{
				case 1: guiTexture.texture = health1; break;
				default: guiTexture.texture = health0; break;
			}
		}
		else if(PlayerSpawner.playerToSpawn == PlayerSpawner.PlayerToSpawn.Player2)
		{
			switch(PlayerLife.playerHealthStatic)
			{
				case 1: guiTexture.texture = health1; break;
				case 2: guiTexture.texture = health2; break;
				default: guiTexture.texture = health0; break;
			}
		}
		else if(PlayerSpawner.playerToSpawn == PlayerSpawner.PlayerToSpawn.Player3)
		{
			switch(PlayerLife.playerHealthStatic)
			{
				case 1: guiTexture.texture = health1; break;
				case 2: guiTexture.texture = health2; break;
				case 3: guiTexture.texture = health3; break;
				default: guiTexture.texture = health0; break;
			}
		}
	}
}
