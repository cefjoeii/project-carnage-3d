using UnityEngine;
using System.Collections;

public class BoomPanesCollision : MonoBehaviour {

	void OnCollisionEnter(Collision other)
	{
		Physics.IgnoreCollision(gameObject.collider, other.collider);
	}
}
