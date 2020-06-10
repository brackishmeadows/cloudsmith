using UnityEngine;
using System.Collections;

//generic script for stuff that can be turned on and off
//like doors and buttons

public class Flag: MonoBehaviour {
	public bool on = false;

	public static int MANUAL = 0; //activated by the grabber script
	public static int COLLIDE = 1; //activate by collision
	public static int OTHER = 2; //activate with some other script
	
	public int activateType = 2; //i guess this should be the default
	
	public void seton (bool _on) { on=_on; }
	
}
