using UnityEngine;
using System.Collections;

public class PowerUpsController : MonoBehaviour {

	private GameObject boomPanes;
	public Texture2D imageToPopUp, speedImage, stopImage, invulnerableImage, evolveImage, boomImage;
	public static string  currentClip;
	private int newSpeed = 1000;
	public static int destroyTime = 6;
	public bool isPowerUpsEnabled;
	public static bool isPowerUpsEnabledStatic, powerUpsReady = true, tanksCanMove = true, popUpNow = false, gotInvulnerability = false;
	 
	void Start()
	{
		boomPanes = GameObject.Find("BoomPanes");
		boomPanes.SetActive(false);
		isPowerUpsEnabledStatic = isPowerUpsEnabled;
		gotInvulnerability = false;
		powerUpsReady = true;
		tanksCanMove = true;
		popUpNow = false;
	}

	public void Speed()
	{
		TankController.realSpeed = newSpeed;
		currentClip = "chickendance";
		imageToPopUp = speedImage;
		StartCoroutine(SpeedDuration());
		MusicChanger();
		StartCoroutine(PopUp());
	}
	
	IEnumerator SpeedDuration()
	{
		yield return new WaitForSeconds(8.453f);
		powerUpsReady = true;
		TankController.realSpeed = TankController.originalSpeed;
		MusicReset();
	}

	public void StopTanks()
	{
		tanksCanMove = false;
		currentClip = "letitgo";
		imageToPopUp = stopImage;
		StartCoroutine(StopTanksDuration());
		MusicChanger();
		StartCoroutine(PopUp());
	}

	IEnumerator StopTanksDuration()
	{
		yield return new WaitForSeconds(8.568f);
		powerUpsReady = true;
		tanksCanMove = true;
		MusicReset();
	}
	
	public void Invulnerability()
	{
		PlayerLife.killable = false;
		InvulnerableEffect.enabled = true;
		gotInvulnerability = true;
		currentClip= "canttouchthis";
		imageToPopUp = invulnerableImage;
		StartCoroutine(InvulnerabilityDuration());
		MusicChanger();
		StartCoroutine(PopUp());
	}

	IEnumerator InvulnerabilityDuration()
	{
		yield return new WaitForSeconds(8.235f);
		powerUpsReady = true;
		InvulnerableEffect.enabled = false;
		PlayerLife.killable = true;
		gotInvulnerability = false;
		MusicReset ();
	}

	public void Evolve()
	{
		imageToPopUp = evolveImage;
		popUpNow = true;
		StartCoroutine(PopUp());
		powerUpsReady = true;
	}

	public void Boom()
	{
		CameraShake.shakeIntensity = .5f;
		CameraShake.shakeDecay = .01f;
		GameObject.FindWithTag("MainCamera").SendMessage("DoShake");
		currentClip= "boompanes";
		imageToPopUp = boomImage;
		StartCoroutine(BoomDuration());
		MusicChanger();
		StartCoroutine(PopUp());
	}

	IEnumerator BoomDuration()
	{
		boomPanes.SetActive(true);
		yield return new WaitForSeconds(1.0f);
		boomPanes.SetActive(false);
		yield return new WaitForSeconds(2.738f);
		powerUpsReady = true;
		MusicReset ();
	}

	void MusicChanger()
	{
		if(ResultShow.victory == false)
		{
			AudioController.audioSource.clip = (AudioClip)Resources.Load(currentClip);
			AudioController.audioSource.volume = 0.8f;
			AudioController.audioSource.loop = false;
			AudioController.audioSource.Play();
			popUpNow = true;
		}
	}

	IEnumerator PopUp()
	{
		if(popUpNow == true && ResultShow.victory == false)
		{
			popUpNow = false;
			yield return new WaitForSeconds(0.5f);
			guiTexture.texture = imageToPopUp;
			guiTexture.enabled = true;
			yield return new WaitForSeconds(1.5f);
			guiTexture.enabled = false;
		}
	}

	void MusicReset()
	{
		if(ResultShow.victory == false && ResultShow.defeat == false)
		{
			AudioController.audioSource.clip = (AudioClip)Resources.Load(AudioController.originalSourceStatic);
			AudioController.audioSource.volume = AudioController.originalVolume;
			AudioController.audioSource.loop = true;
			AudioController.audioSource.Play();
		}
	}
}
