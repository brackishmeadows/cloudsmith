using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	private Vector3 closedpos;
	private Vector3 openpos;
	
	private float height;
	private float heightoffset = -.1f; //meters. distance between open and closed position is a little different from the actual height of the door
	
	private Vector3 targetpos;
	private float openness = 0; //between 0 and 1
	public float openDuration = 1; //seconds

	void Start () {
		
		height = transform.localScale.y +heightoffset; //distance between open and closed position
		
		closedpos = transform.position; //0		
		openpos = transform.position + new Vector3( 0, height, 0 );  //0+height
	}

	void Update () {
		Flag flag = GetComponent<Flag>();
		float openamount = (Time.deltaTime / openDuration);
			
		openness += ( flag.on? openamount : -openamount );
		
		openness = Mathf.Clamp (openness, 0, 1);
		
		transform.position = Vector3.Lerp(closedpos, openpos, openness );		
	}
}
