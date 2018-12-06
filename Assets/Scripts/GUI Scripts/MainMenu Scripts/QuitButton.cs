using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {

	public Texture2D normal, hover;

	void OnMouseEnter() { guiTexture.texture = hover; }
	void OnMouseExit() { guiTexture.texture = normal; }
	void OnMouseDown()
	{
		if(GameObject.Find ("ResultShow"))
		{
			GameObject.Find ("ResultShow").GetComponent<ResultShow>().ScoreChecker();
		}
		guiTexture.texture = normal;
		Application.Quit();
	}

}
