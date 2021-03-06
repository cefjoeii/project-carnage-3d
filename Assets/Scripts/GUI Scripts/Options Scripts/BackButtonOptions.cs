﻿using UnityEngine;
using System.Collections;

public class BackButtonOptions : MonoBehaviour {

	public Texture2D normal, hover;
	
	void OnMouseEnter() { guiTexture.texture = hover; }
	void OnMouseExit() { guiTexture.texture = normal; }
	void OnMouseDown()
	{
		guiTexture.texture = normal;
		GUIHolderMainMenu.mainMenuHolder.SetActive(true);
		GUIHolderMainMenu.optionsHolder.SetActive(false);
	}
}
