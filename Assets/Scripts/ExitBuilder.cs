using UnityEngine;
using System.Collections;

public class ExitBuilder : MonoBehaviour {
	private GameObject spawn;
	private LevelBuildGui script;
	// Use this for initialization
	void Start () {
		spawn = GameObject.FindWithTag ("GameController");
		script = spawn.GetComponent<LevelBuildGui> ();
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player"){
			print(spawn);
			script.play = false;
			script.select = "none";
			script.menu = 0;
		}
	}
}
