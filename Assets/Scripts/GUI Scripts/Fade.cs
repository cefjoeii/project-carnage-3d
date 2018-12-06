using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.3f;
	private int drawDepth = -1000; // low value means on "TOP" :D
	private float alpha = 1.0f; //alpha means opacity
	private int fadeDirection = -1; // -1 = fade in : 1 = fade out 

	void OnGUI()
	{
		alpha += fadeDirection * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth; // to make the black render on TOP :D
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), fadeOutTexture);
	}

	public float BeginFade(int direction)
	{
		fadeDirection = direction;
		return (fadeSpeed); // to be synchronised with the time of Application.LoadLevel() time :D
	}

	void OnLevelWasLoaded()
	{
		BeginFade(-1);
	}
}