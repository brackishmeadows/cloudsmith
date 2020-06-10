using UnityEngine;
using System.Collections;

	//press a key to pick stuff up and drop stuff
	//this script goes on a collider attached to the camera
	//there's a bug where you can drop stuff through walls, i'm not sure how to fix that without using forces.
	

public class Grabber : MonoBehaviour {

	public string key = "e"; // this key picks up stuff and drops it
	private bool keypressed = false; //true once the key is down, false once it is released
	
	private bool hasthing = false; //whether we're currently grabbing something
	private GameObject grabbedthing;

	void Start(){
	Screen.lockCursor = true;
	}
	
	//------------------------------------------------
	void Update() {
		checkkey();
		
		if (hasthing) {
			if (keypressed)	release();
		}
	}
	
	//------------------------------------------------
	void OnTriggerStay (Collider other) {
		
		if (keypressed) {
			activate(other.gameObject);
			
			if (!hasthing) {
				if (other.gameObject.CompareTag("crate")){
					grab(other.gameObject);
			}		
		}
			
		}

	}
	
	//------------------------------------------------
	void checkkey(){
		if (keypressed) {
			if (Input.GetKeyUp (key)) {
				keypressed = false;
			}
		}
		else if (Input.GetKeyDown (key)) {
			keypressed = true;
		}
	}
	
	void activate(GameObject other){
		//if the other has a flag component that the player activates manually
		//set it to on
		Flag flag = (Flag) other.GetComponent("Flag");
		print(flag);
		if( (flag != null)
		&&	(keypressed)
		&&  (flag.activateType == Flag.MANUAL)
		)
			flag.on = true;		
	}
	
	//------------------------------------------------
	void grab(GameObject other) {
		other.transform.parent = this.transform;	
		other.rigidbody.isKinematic = true;
		other.rigidbody.useGravity = false;
		hasthing = true;
		grabbedthing = other;
		keypressed = false;
		
	}
	
	//------------------------------------------------
	void release() {
		grabbedthing.transform.parent = null;	
		grabbedthing.rigidbody.isKinematic = false;
		grabbedthing.rigidbody.useGravity = true;
		hasthing = false;
		keypressed = false;
	}
	

	

	
}
