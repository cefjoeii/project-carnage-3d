using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {
	public Transform sparksPrefab;

	void OnCollisionEnter(Collision other)
	{
		Instantiate(sparksPrefab, gameObject.transform.localPosition, gameObject.transform.localRotation);
		Destroy(gameObject);
	}

}
