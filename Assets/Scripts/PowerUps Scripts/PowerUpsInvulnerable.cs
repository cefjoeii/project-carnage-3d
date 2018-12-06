using UnityEngine;
using System.Collections;

public class PowerUpsInvulnerable : MonoBehaviour {

	public Transform powerUpsEffects;
	private int points = 400;

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
			GameObject.Find("PowerUpsController").GetComponent<PowerUpsController>().Invulnerability();
			Instantiate(powerUpsEffects, transform.localPosition, transform.localRotation);
			Score.currentScore += points;
			Destroy(gameObject);
		}
	}
}
