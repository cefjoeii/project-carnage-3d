using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;

public class ResultShow : MonoBehaviour {
	
	public Texture2D victoryImage, defeatImage, missionStartImage;
	public static string levelToLoad;
	public int killCounter;
	private float showDelay = 2.0f, nextLevelDelayForVictory = 8.0f, nextLevelDelayForDefeat = 4.0f;
	public static bool victory = false, defeat = false;
	private string hiscore, path, filename;

	IEnumerator Start()
	{
		victory = false;
		defeat = false;
		killCounter = 0;
		guiTexture.texture = missionStartImage;
		yield return new WaitForSeconds(2.0f);
		guiTexture.enabled = true;
		yield return new WaitForSeconds(1.5f);
		guiTexture.enabled = false;
	}

	void Update() { StartCoroutine(ShowResult()); }

	IEnumerator ShowResult()
	{
		if(killCounter >= GameObject.Find("AiSpawner").GetComponent<AiSpawner>().numberOfSpawns)
		{
			victory = true;
			killCounter = 0;
			guiTexture.texture = victoryImage;
			yield return new WaitForSeconds(showDelay);
			guiTexture.enabled = true;
			AudioController.audioSource.clip = (AudioClip)Resources.Load("Niceterium");
			AudioController.audioSource.volume = 0.9f;
			AudioController.audioSource.loop = false;
			AudioController.audioSource.Play ();
			PlayerSpawner.spawnPlayerNow = false; //Trust me, you will need this
			yield return new WaitForSeconds(nextLevelDelayForVictory);
			RandomFacts.levelToLoad = levelToLoad;
			Application.LoadLevel("randomfacts");
			guiTexture.enabled = false;
			ScoreChecker();
		}
		else if(PlayerSpawner.playerLife <= 0 && defeat == false)
		{
			defeat = true;
			guiTexture.texture = defeatImage;
			yield return new WaitForSeconds(showDelay);
			guiTexture.enabled= true;
			AudioController.audioSource.clip = (AudioClip)Resources.Load("LudusPerditus");
			AudioController.audioSource.volume = 0.9f;
			AudioController.audioSource.loop = true;
			AudioController.audioSource.Play ();
			PlayerSpawner.spawnPlayerNow = false; //Trust me, you will need this
			yield return new WaitForSeconds(nextLevelDelayForDefeat);
			GUIHolderLevels.gameOverHolder.SetActive(true);
			guiTexture.enabled = false;
			ScoreChecker();
		}
	}

	public void ScoreChecker()
	{
		path = Application.dataPath;
		filename = "/hiscore.geisha";

		//to open the file (don't get confused)
		using(FileStream fs = File.OpenRead(path + filename))
		{
			byte[] b = new byte[1024];
			UTF8Encoding temp = new UTF8Encoding(true);
			while(fs.Read (b,0,b.Length) > 0)
			{
				hiscore = temp.GetString(b);
			}
		}
	
		//to check the value of the file that was opened (don't get confused) 
		if(Score.currentScore > Convert.ToInt32(hiscore))
		{
			using(FileStream fs = File.Create(path + filename))
			{
				AddText(fs, Score.currentScore.ToString());
			}
		}
	}

	public static void AddText(FileStream fs, string value)
	{
		byte[] b = new UTF8Encoding(true).GetBytes(value);
		fs.Write(b, 0, b.Length);
	}
}
