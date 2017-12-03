using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interestingify : MonoBehaviour {

  private Vector3 initialScale;

  private float randScaleTime;
  private float randRotTime;
  private float rotMult;

	// Use this for initialization
	void Start () {
    initialScale = transform.localScale;
    randScaleTime = Random.value * 2 * 3.1415f;
    randRotTime = Random.value * 2 * 3.1415f;
    rotMult = Random.value + 1;
	}
	
	// Update is called once per frame
	void Update () {
    transform.localScale = initialScale * ( 1.0f + ( Mathf.Sin( ( Time.time + randScaleTime ) % (2*3.1415f) ) / 10 ) );
    transform.eulerAngles = new Vector3(0, 0, 10 * Mathf.Cos( ( ( Time.time + randRotTime ) * rotMult ) % (2*3.1415f) ) );	
	}
}
