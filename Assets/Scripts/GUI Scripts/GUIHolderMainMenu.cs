using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;


public class GUIHolderMainMenu : MonoBehaviour {
	public static GameObject hiScoreObject, mainMenuHolder, levelSelectionHolder, optionsHolder, creditsHolder, controlsHolder, audioHolder, hiScoreHolder;
	private string hiscore, path, filename;

	void Start()
	{
		path = Application.dataPath;
		filename = "/hiscore.geisha";
		hiScoreObject = GameObject.Find ("HiScore");

		mainMenuHolder = GameObject.Find("MainMenuHolder");
		mainMenuHolder.SetActive(true);
		levelSelectionHolder = GameObject.Find("LevelSelectionHolder");
		levelSelectionHolder.SetActive(false);
		optionsHolder = GameObject.Find("OptionsHolder");
		optionsHolder.SetActive(false);
		creditsHolder = GameObject.Find("CreditsHolder");
		creditsHolder.SetActive(false);
		controlsHolder = GameObject.Find("ControlsHolder");
		controlsHolder.SetActive(false);
		audioHolder = GameObject.Find("AudioHolder");
		audioHolder.SetActive(false);
		hiScoreHolder = GameObject.Find("HiScoreHolder");
		hiScoreHolder.SetActive(true);
	}

	void Update()
	{
		using(FileStream fs = File.OpenRead(path + filename))
		{
			byte[] b = new byte[1024];
			UTF8Encoding temp = new UTF8Encoding(true);
			while(fs.Read (b,0,b.Length) > 0)
			{
				hiscore = temp.GetString(b);
			}
		}
		hiScoreObject.guiText.text = hiscore;
	}
}
