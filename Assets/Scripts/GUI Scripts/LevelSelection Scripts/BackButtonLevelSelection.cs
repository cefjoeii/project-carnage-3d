using UnityEngine;
using System.Collections;

public class BackButtonLevelSelection : MonoBehaviour {

	public Texture2D normal, hover;
	
	void OnMouseEnter() { guiTexture.texture = hover; }
	void OnMouseExit() { guiTexture.texture = normal; }
	void OnMouseDown()
	{
		guiTexture.texture = normal;
		GUIHolderMainMenu.mainMenuHolder.SetActive(true);
		GUIHolderMainMenu.levelSelectionHolder.SetActive(false);
		GUIHolderMainMenu.hiScoreHolder.SetActive(true);
	}
}
