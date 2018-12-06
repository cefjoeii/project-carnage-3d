using UnityEngine;
using System.Collections;

public class gameoverOnDamage : MonoBehaviour {
	
	public GUIText mText;
	public GameObject playerTank;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void TakeDamage(GameObject shooter)
	{	
		//Debug.Log("TakeDamage " + gameObject.name);
		mText.gameObject.active = true;
		Time.timeScale = 0;
		DestroyObject(this.gameObject);
		DestroyObject(playerTank);
	}
}
