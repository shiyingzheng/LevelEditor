/*Peter Aguiar
 * Drag.cs moves objects in level editor.
 * 
 * OnMouseDrag is called when a collider is clicked on, the spawn point Vector3 is changed according to location of mouse. 
 * 
 * When OnMouseOver + middle mouse button is detected, object Destroys itself.
 * 
 * Start looks for Gamecontroller script with LevelBuildGui script, change GameController to whatever the LevelBuildGui script is on.
 * 
 * Update says that if not in play mode, keep object at spawn point. 
*/
using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {
	public Vector3 spawn_Position;

	private GameObject spawn;
	private LevelBuildGui script;
	void OnMouseDrag(){
		if (!script.play) {
			Vector3 locale = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			locale.z = 0;
			transform.position = locale;
			spawn_Position = locale;
		}
		}
	void OnMouseOver(){
		if (Input.GetMouseButtonDown (2)) {
			Destroy (gameObject);
		}
	}

	void Start(){
		spawn = GameObject.FindWithTag ("GameController");
		script = spawn.GetComponent<LevelBuildGui> ();
		spawn_Position = transform.position;
		

	}
	public void export_Fucks(){
		string myName = this.transform.name;
		print (myName);
		if (myName == "Pounce Enemy") {
			print("FUCKYOU IM A POUNCE ENEMY BITCH");
			script.pouncePosition (transform.position);
		} else if (myName == "Slow Enemy") {
			script.slowPosition (transform.position);
		}else if (myName == "Fast Enemy") {
			script.fastPosition (transform.position);
		}else if (myName == "Ranged Enemy") {
			script.rangedPosition (transform.position);
		}else if (myName == "Vision Tower") {
			script.towerPosition (transform.position);
		}
	}
	void Update(){
		if (!script.play) {
			transform.position = spawn_Position;

		} 
	}
}
