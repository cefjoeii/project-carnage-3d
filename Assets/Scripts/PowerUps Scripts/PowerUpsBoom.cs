using UnityEngine;
using System.Collections;

public class PowerUpsBoom : MonoBehaviour {

	public Transform powerUpsEffects;
	private int  points = 1000;

	IEnumerator Start()
	{
		PowerUpsController.powerUpsReady = false;
		yield return new WaitForSeconds(PowerUpsController.destroyTime);
		PowerUpsController.powerUpsReady = true;
		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision other)
	{
		Physics.IgnoreCollision(gameObject.collider, other.collider);
		if(other.gameObject.tag == "Player")
		{
			GameObject.Find("PowerUpsController").GetComponent<PowerUpsController>().Boom();
			Instantiate(powerUpsEffects, transform.localPosition, transform.localRotation);
			Score.currentScore += points;
			Destroy(gameObject);
		}
	}
}
