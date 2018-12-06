using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {
	void Update() { guiText.text = PlayerSpawner.playerLife.ToString(); }
}
