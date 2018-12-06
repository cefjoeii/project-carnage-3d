using UnityEngine;
using System.Collections;

public class ControlsButton : MonoBehaviour {

	public Texture2D normal, hover;
	
	void OnMouseEnter() { guiTexture.texture = hover; }
	void OnMouseExit() { guiTexture.texture = normal; }
	void OnMouseDown()
	{
		guiTexture.texture = normal;
		GUIHolderMainMenu.optionsHolder.SetActive(false);
		GUIHolderMainMenu.controlsHolder.SetActive(true);
	}


}
