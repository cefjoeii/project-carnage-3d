using UnityEngine;
using System.Collections;

public class AiInputHandler : MonoBehaviour {

	public AiTankController controller;
	public float directionSwitcherTime = 3;	
	public float _directionSwitcherTimer = 3;

	void Start () { controller = GetComponent<AiTankController>(); }

	void Update () 
	{
		_directionSwitcherTimer -= Time.deltaTime;
			
		if (_directionSwitcherTimer <= 0)
		{
			_directionSwitcherTimer = directionSwitcherTime;
			if(PowerUpsController.tanksCanMove)
			{
				controller.direction = (AiTankController.goDirection) Random.Range(0, 4);
			}
		}
	}
}
