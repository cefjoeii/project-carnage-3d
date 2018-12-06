using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int currentScore = 0;

	void Update() { guiText.text = currentScore.ToString(); }
}
