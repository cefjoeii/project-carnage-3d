﻿using UnityEngine;
using System.Collections;

public class Button2 : MonoBehaviour {

	public Texture2D normal, hover;

	void OnMouseEnter() { guiTexture.texture = hover; }
	void OnMouseExit() { guiTexture.texture = normal; }
	void OnMouseDown()
	{
		guiTexture.texture = normal;
		PlayerSpawner.spawnPlayerNow = false;
		PlayerSpawner.playerLife = 2;
		Score.currentScore = 0;
		PowerUpsController.isPowerUpsEnabledStatic = true;
		PowerUpsController.tanksCanMove = true;
		RandomFacts.levelToLoad = "level2";
		Application.LoadLevel("randomfacts");
	}
}
