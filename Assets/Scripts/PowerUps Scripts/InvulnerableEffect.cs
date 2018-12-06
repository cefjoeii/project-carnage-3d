using UnityEngine;
using System.Collections;

public class InvulnerableEffect : MonoBehaviour {

	public static bool enabled = true;

	void Update ()
	{
		if(enabled == true)
			gameObject.particleEmitter.emit = true;
		if(enabled == false)
			gameObject.particleEmitter.emit = false;
	}

}