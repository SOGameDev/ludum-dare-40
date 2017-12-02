using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

  public  Rigidbody2D  possessed_object;
  private float        speed = 250.0f;

  private bool  time_up = false;
  private Timer timer;

  void Start () {
    timer = GameObject.Find( "Timer" ).GetComponent<Timer>();
    timer.timerEnd += new EventHandler( TimerEndHandler );

    time_up = false;
  }

  void FixedUpdate () {
    if ( time_up )
    {
      return;
    }

    Vector2 input = new Vector2( Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") );

    if ( input.magnitude < 0.3 && possessed_object.velocity.magnitude > 1 )
    {
      possessed_object.velocity *= 0.3f;
    }
    else
    {
      possessed_object.AddForce( input.normalized * speed * Time.deltaTime, ForceMode2D.Impulse );
    }
  }

  void TimerEndHandler ( object _, EventArgs __ ) {
    time_up = true;
  }
}
