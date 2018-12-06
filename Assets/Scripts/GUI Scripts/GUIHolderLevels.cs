using UnityEngine;
using System.Collections;

public class GUIHolderLevels : MonoBehaviour {

	public static GameObject pauseHolder, gameOverHolder, guiBoard;
	public static bool pauseToggle = false;

	void Start()
	{
		pauseHolder = GameObject.Find("PauseHolder");
		pauseHolder.SetActive(false);
		gameOverHolder = GameObject.Find("GameOverHolder");
		gameOverHolder.SetActive(false);
		guiBoard = GameObject.Find("GUIBoard");
		guiBoard.SetActive(true);
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape) && ResultShow.victory == false && ResultShow.defeat == false && GameObject.Find("ResultShow").GetComponent<ResultShow>().guiTexture.enabled == false)
		{
			pauseToggle = !pauseToggle;
			if(pauseToggle == true)
			{
				Time.timeScale = 0.0f;
				GameObject.Find("Main Camera").GetComponent<AudioSource>().Pause();
				pauseHolder.SetActive(true);
				guiBoard.SetActive(false);
			}
			else
			{
				Time.timeScale = 1.0f;
				GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
				pauseHolder.SetActive(false);
				guiBoard.SetActive(true);
			}
		}
	}

}
