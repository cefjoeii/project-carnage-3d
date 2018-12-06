using UnityEngine;
using System.Collections;

public class directionSwitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col)
	{
		AiInputHandler ai = transform.parent.GetComponent<AiInputHandler>();
		if (ai)
		{
			if (ai.controller)
				ai.controller.direction -= 1;
		}
	}
}
