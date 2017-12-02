using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possessor : MonoBehaviour {

  public  Transform  highlight_prefab;
  private Transform  highlight = null;

  private Collider2D possession_target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void OnTriggerEnter2D ( Collider2D other ) {
    possession_target = other;

    if ( highlight != null )
    {
      highlight.position = other.gameObject.transform.position;
    }
    else
    {
      highlight = Instantiate(highlight_prefab, other.gameObject.transform.position, Quaternion.identity);
    }
  }

  void OnTriggerExit2D ( Collider2D other ) {
    if ( highlight != null && other == possession_target )
    {
      Destroy( highlight.gameObject );
      highlight = null;
    }
  }
}
