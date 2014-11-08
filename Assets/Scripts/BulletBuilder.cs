using UnityEngine;
using System.Collections;

public class BulletBuilder : MonoBehaviour {
	private GameObject spawn;
	private LevelBuildGui script;
	// Use this for initialization
	void Start () {
		spawn = GameObject.FindWithTag ("GameController");
		script = spawn.GetComponent<LevelBuildGui> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!script.play) {
						Destroy (gameObject);
				}
	}
}
