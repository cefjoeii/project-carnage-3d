using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	public MovieTexture gameIntroVideo;
	
	IEnumerator Checker()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Application.LoadLevel("mainmenu");
		}
		yield return new WaitForSeconds(86);
		Application.LoadLevel("mainmenu");
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameIntroVideo);
		gameIntroVideo.Play();
		StartCoroutine(Checker());
	}

}

























