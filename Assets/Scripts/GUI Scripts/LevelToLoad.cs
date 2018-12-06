using UnityEngine;
using System.Collections;

public class LevelToLoad : MonoBehaviour{

	public string levelToLoad;

	void Start () { ResultShow.levelToLoad = levelToLoad; }

}
