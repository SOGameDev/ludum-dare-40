using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possessor : MonoBehaviour {

  public  Transform  highlight_prefab;
  private Transform  highlight = null;

  private Timer          timer;
  private bool           time_up = false;

  private Collider2D     possession_target = null;
  private movement       movement_controller = null;
  private SpriteRenderer rend;

  void Start () {
    movement_controller = GameObject.Find( "Movement Controller" ).GetComponent<movement>();
    rend = gameObject.GetComponent<SpriteRenderer>();

    timer = GameObject.Find( "Timer" ).GetComponent<Timer>();
    timer.timerEnd += new EventHandler( TimerEndHandler );

    time_up = false;
  }

	void Update () {
    if ( time_up )
    {
      return;
    }

    // we want to possess something
    if ( Input.GetButtonDown("Possess") && movement_controller.possessed_object.gameObject == gameObject && possession_target != null ) {
      movement_controller.possessed_object = possession_target.gameObject.GetComponent<Rigidbody2D>();
      rend.enabled = false;
    }

    // we want to stop possessing something
    else if ( Input.GetButtonDown("Possess") && movement_controller.possessed_object.gameObject != gameObject ) {
      transform.position = movement_controller.possessed_object.position;
      movement_controller.possessed_object = gameObject.GetComponent<Rigidbody2D>();
      rend.enabled = true;
    }

    // if we've possessed something, move with it
    if ( !rend.enabled && highlight != null )
    {
      highlight.position = movement_controller.possessed_object.position;
      gameObject.transform.position = movement_controller.possessed_object.position;
    }
	}

  void OnTriggerEnter2D ( Collider2D other ) {
    if ( !rend.enabled )
    {
      return;
    }
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
    if ( !rend.enabled )
    {
      return;
    }
    if ( highlight != null && other == possession_target )
    {
      Destroy( highlight.gameObject );
      highlight = null;
      possession_target = null;
    }
  }

  void TimerEndHandler ( object _, EventArgs __ ) {
    time_up = true;
  }
}
