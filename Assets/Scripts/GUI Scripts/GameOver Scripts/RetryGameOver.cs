using UnityEngine;
using System.Collections;

public class RetryGameOver : MonoBehaviour {

	public Texture2D normal, hover;
	
	void OnMouseEnter() { guiTexture.texture = hover; }
	void OnMouseExit() { guiTexture.texture = normal; }
	void OnMouseDown()
	{
		guiTexture.texture = normal;

		PlayerSpawner.spawnPlayerNow = false;
		PlayerSpawner.playerLife = 2;
		PlayerLife.killable = false;
		Score.currentScore = 0;
		
		PowerUpsController.popUpNow = false;
		PowerUpsController.isPowerUpsEnabledStatic = true;
		PowerUpsController.powerUpsReady = true;
		PowerUpsController.gotInvulnerability = false;
		PowerUpsController.tanksCanMove = true;
		ResultShow.victory = false;
		ResultShow.defeat = false;

		Application.LoadLevel(Application.loadedLevel);
	}
}
