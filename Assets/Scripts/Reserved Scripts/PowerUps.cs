using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {
	
	public float curHP = 100;
	public float maxHP = 100;
	public float maxBAR = 100;
	public float HealthBarLength;
	public float Movementspeed = 20;
	
	void OnGUI()
	{
		GUI.Box (new Rect (10, 10, HealthBarLength, 25), "");
		HealthBarLength = curHP * maxBAR / maxHP;
	}
	
	void changeHP(float change)
	{
		curHP += change;
		if (curHP > 100) 
		{
			curHP = 100;
		}
		if (curHP <= 0) 
		{
			Debug.Log("Player is Dead... Mission fail!");
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		switch(other.gameObject.tag)
		{
		case "Heal":
			changeHP(25);
			break;
			
		case "Acid":
			changeHP(-25);
			break;
		case "SpeedUp":
			Movementspeed = 100;
			break;
		default:
			break;
		}
		Destroy (other.gameObject);
	}
}
