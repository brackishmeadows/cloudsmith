using UnityEngine;
using System.Collections;

public class TimerButton : MonoBehaviour {
	public Flag target;
	private bool previouslyon = false;
	private float onat = 0; //seconds
	public float switchDuration = 1; //seconds
	
	void Update () {
		Flag flag = GetComponent<Flag>();
		if (flag.on) {
			target.seton(flag.on);
			
			print("on " +Time.time);
			
			if(!previouslyon) {
				onat = Time.time;
				previouslyon = true;
			}
			
			else if (Time.time > onat+switchDuration) {
				flag.seton(false);
				target.seton(false);
				previouslyon = false;
			}		
		
		}
		
			
	}
	
}
