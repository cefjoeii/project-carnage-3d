using UnityEngine;
using System.Collections;

public class ResumeButton : MonoBehaviour {

	public Texture2D normal, hover;

	void OnMouseEnter() { guiTexture.texture = hover; }
	void OnMouseExit() { guiTexture.texture = normal; }
	void OnMouseDown()
	{
		guiTexture.texture = normal;
		GUIHolderLevels.pauseToggle = !GUIHolderLevels.pauseToggle;
		Time.timeScale = 1.0f;
		GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
		GUIHolderLevels.pauseHolder.SetActive(false);
		GUIHolderLevels.guiBoard.SetActive(true);
	}

}
