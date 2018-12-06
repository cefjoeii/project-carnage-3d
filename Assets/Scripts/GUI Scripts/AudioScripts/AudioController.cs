using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	
	public static AudioSource audioSource;
	public string originalSource;
	public static string originalSourceStatic;
	public static float originalVolume = .1f;

	void Start()
	{
		originalSourceStatic = originalSource;
		audioSource = (AudioSource)GameObject.Find("Main Camera").GetComponent("AudioSource");
		audioSource.volume = originalVolume;
	}
}
