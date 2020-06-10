using UnityEngine;
using System.Collections;

public class WeightButton: MonoBehaviour {
	public Flag target;
	
	void OnCollisionStay (Collision other) {
		if( (other.gameObject.CompareTag("crate"))
		) target.seton(true);
			
	}
	
	void OnCollisionExit (Collision other) {
		if( (other.gameObject.CompareTag("crate"))
		) target.seton(false);
			
	}
}
