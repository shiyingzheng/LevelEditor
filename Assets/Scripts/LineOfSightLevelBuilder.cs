/*Peter Aguiar
 * 10/6/2014
 * LineOfSight creates basic line of sight for an enemy 
 * that does not see through "barriers".
 * cs 361
 * 
 * November 4th
 * Added lines in start and update that cause the circle collider to shrink when not in play mode to avoid interference with Drag.cs 
*/
using UnityEngine;
using System.Collections;
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
public class LineOfSightLevelBuilder : MonoBehaviour {
	
	public bool spotted = false; 
	public int playerLayer;
	public GameObject enemyObject;
	public string maskingLayerName;
	
	public float radius = 15.0f;
	
	private GameObject spawn;
	private LevelBuildGui script;
	private CircleCollider2D myCollider;
	
	private /*-->*/ Enemy /*<--*/ enemyScript; //!!!! YOU MIGHT NEED TO CHANGE !!!!
	
	//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
	void Start(){
		if (enemyObject != null) { //Checks to see if enemy object exists.
			enemyScript = enemyObject.GetComponent </*!!!!->*/ Enemy /*<-!!!!*/> (); // !!!!  YOU MIGHT NEED TO CHANGE !!!!
		}
		if (enemyObject == null) {
			Debug.Log ("Can't find player object!"); //Debug
		}
		spawn = GameObject.FindWithTag ("GameController");
		script = spawn.GetComponent<LevelBuildGui> ();
		myCollider = transform.GetComponent<CircleCollider2D> ();
	}
	//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
	void Update () {
		
		if (spotted && enemyObject != null) { //If player is spotted and the enemy exists
			enemyScript./*-->*/ inLineOfSight /*<--*/ = true; //!!!! YOU MIGHT NEED TO CHANGE !!!!
			
		} else {
			enemyScript./*-->*/ inLineOfSight /*<--*/ = false; //!!!! YOU MIGHT NEED TO CHANGE !!!!
		}
		if (!script.play) {
			myCollider.radius = 1.0f;
			
		} else {
			myCollider.radius = radius;
		}
	}
	//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
	void sight(Transform other){
		
		Debug.DrawLine (transform.position, other.position, Color.red); //In the scene view during play, a red line will be drawn to illustrate line of sight.
		if (!Physics2D.Linecast (transform.position, other.position, 1 << LayerMask.NameToLayer (maskingLayerName)) // Check is Objects will obscure vision.
		    ) {
			spotted = true; //Player is spotted.
		} else {
			spotted = false; //Player not in sight or something obscured vision. 
		}
	}
	//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
	void OnTriggerStay2D (Collider2D other){ //Checks objects within collider. 
		
		
		if(other.tag == "Player"){ //If an object tagged "Player" comes into the collider
			
			sight(other.transform); //Check to see if it can be seen. 
		}
	}
	//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
	void OnTriggerExit2D(Collider2D other){ 
		if (other.tag == "Player") { //When Player leaves line of sight.
			spotted = false; //The enemy cannot see the player. 
		}
	}
	
	
	//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
	
}
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
