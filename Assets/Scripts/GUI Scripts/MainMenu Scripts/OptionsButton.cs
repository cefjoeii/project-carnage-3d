using UnityEngine;
using System.Collections;

public class OptionsButton : MonoBehaviour {

	public Texture2D normal, hover;

	void OnMouseEnter() { guiTexture.texture = hover; }
	void OnMouseExit() { guiTexture.texture = normal; }
	void OnMouseDown()
	{
		guiTexture.texture = normal;
		GUIHolderMainMenu.optionsHolder.SetActive(true);
		GUIHolderMainMenu.mainMenuHolder.SetActive(false);
	}

}
