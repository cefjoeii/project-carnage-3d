using UnityEngine;
using System.Collections;

public class BackButtonAudio : MonoBehaviour {

	public Texture2D normal, hover;
	
	void OnMouseEnter() { guiTexture.texture = hover; }
	void OnMouseExit() { guiTexture.texture = normal; }
	void OnMouseDown()
	{
		guiTexture.texture = normal;
		AudioController.originalVolume = AudioController.audioSource.volume;
		GUIHolderMainMenu.optionsHolder.SetActive(true);
		GUIHolderMainMenu.audioHolder.SetActive(false);
	}
}
