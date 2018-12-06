using UnityEngine;
using System.Collections;

public class CreditsButton : MonoBehaviour {

	public Texture2D normal, hover;

	void OnMouseEnter() { guiTexture.texture = hover; }
	void OnMouseExit() { guiTexture.texture = normal; }
	void OnMouseDown()
	{
		guiTexture.texture = normal;
		GUIHolderMainMenu.creditsHolder.SetActive(true);
		GUIHolderMainMenu.mainMenuHolder.SetActive(false);
	}

}
