using UnityEngine;
using System.Collections;

public class AudioButton : MonoBehaviour {

	public Texture2D normal, hover;
	
	void OnMouseEnter() { guiTexture.texture = hover; }
	void OnMouseExit() { guiTexture.texture = normal; }
	void OnMouseDown()
	{
		guiTexture.texture = normal;
		GUIHolderMainMenu.audioHolder.SetActive(true);
		GUIHolderMainMenu.optionsHolder.SetActive(false);
	}


}
