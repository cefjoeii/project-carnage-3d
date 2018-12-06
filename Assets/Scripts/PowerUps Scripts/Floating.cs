using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour {

	public int force;
	public float lowestPositionY, highestPositionY;

	void Update()
	{
		if(GUIHolderLevels.pauseHolder.activeSelf == false)
		{
			if(transform.position.y <= lowestPositionY)
				rigidbody.AddForce(transform.up * force);
			if(transform.position.y >= highestPositionY)
				rigidbody.AddForce((-transform.up * force)/2);
		}
	}
}
