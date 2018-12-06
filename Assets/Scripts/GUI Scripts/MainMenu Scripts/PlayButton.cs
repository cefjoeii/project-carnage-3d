using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {
	public Texture2D normal, hover;
	
	void OnMouseEnter() { guiTexture.texture = hover; }
	void OnMouseExit() { guiTexture.texture = normal; }
	void OnMouseDown()
	{
		guiTexture.texture = normal;
		GUIHolderMainMenu.levelSelectionHolder.SetActive(true);
		GUIHolderMainMenu.mainMenuHolder.SetActive(false);
		GUIHolderMainMenu.hiScoreHolder.SetActive(false);
	}

}
