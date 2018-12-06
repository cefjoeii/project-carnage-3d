using UnityEngine;
using System.Collections;

public class MinusButton : MonoBehaviour {

	public Texture2D normal, hover;

	void OnMouseEnter() { guiTexture.texture = hover; }
	void OnMouseExit() { guiTexture.texture = normal; }
	void OnMouseDown()
	{
		guiTexture.texture = normal;
		if(AudioController.audioSource.volume >= 0.2f)
			AudioController.audioSource.volume -= .1f;
	}
	void OnMouseUp() { guiTexture.texture = hover; }
}
