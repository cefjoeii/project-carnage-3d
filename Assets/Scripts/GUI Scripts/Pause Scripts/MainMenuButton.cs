using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour {

	public Texture2D normal, hover;
	
	void OnMouseEnter() { guiTexture.texture = hover; }
	void OnMouseExit() { guiTexture.texture = normal; }
	void OnMouseDown()
	{
		if(GameObject.Find ("ResultShow"))
		{
			GameObject.Find ("ResultShow").GetComponent<ResultShow>().ScoreChecker();
		}
		guiTexture.texture = normal;
		GUIHolderLevels.pauseHolder.SetActive(false);
		GUIHolderLevels.guiBoard.SetActive(false);
		GUIHolderLevels.pauseToggle =! GUIHolderLevels.pauseToggle;
		Time.timeScale = 1.0f;
		PowerUpsController.isPowerUpsEnabledStatic = false;
		PowerUpsController.tanksCanMove = true;
		PlayerSpawner.playerToSpawn = PlayerSpawner.PlayerToSpawn.Player1;
		Application.LoadLevel("mainmenu");
	}
}
