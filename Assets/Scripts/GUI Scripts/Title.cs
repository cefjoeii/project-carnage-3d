using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	public Texture2D title;

	void OnGUI ()
	{
		if(title != null) { GUI.DrawTexture(new Rect(0,0,title.width,title.height), title); }
	}
}

























