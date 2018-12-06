using UnityEngine;
using System.Collections;

public class RandomFacts : MonoBehaviour {
	private int randomNumber; //right now, we only have 10 facts
	public Texture2D fact1,fact2,fact3,fact4,fact5,fact6,fact7,fact8,fact9,fact10;
	public static string levelToLoad; //static so that we can modify it anywhere :)

	IEnumerator Start()
	{
		randomNumber = Random.Range (1,11);
		yield return new WaitForSeconds(5);
		Application.LoadLevel(levelToLoad);
	}
	
	void OnGUI() { RandomPicture(); }

	void RandomPicture()
	{
		switch (randomNumber)
		{
			case 1: GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), fact1); break;
			case 2: GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), fact2); break;
			case 3: GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), fact3); break;
			case 4: GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), fact4); break;
			case 5: GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), fact5); break;
			case 6: GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), fact6); break;
			case 7: GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), fact7); break;
			case 8: GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), fact8); break;
			case 9: GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), fact9); break;
			case 10: GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), fact10); break;
		}
	}
}
