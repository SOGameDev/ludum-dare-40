using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

  public float seconds_remaining = 120;
  public event EventHandler timerEnd;

  private bool started = false;

  void FixedUpdate() {
    Vector2 input = new Vector2( Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") );
    if ( input.magnitude > 0.3 && seconds_remaining > 0 )
    {
      started = true;
    }

    if ( started )
    {
      seconds_remaining -= Time.deltaTime;
    }

    if ( seconds_remaining < 0 )
    {
      seconds_remaining = 0;
      started = false;
      if ( timerEnd )
      {
        timerEnd(this, EventArgs.Empty);
      }
    }
  }

  void OnGUI() {
    int   minutes  = (int)Mathf.Floor(seconds_remaining/60);
    int   seconds  = (int)(Mathf.Floor(seconds_remaining) % 60);
    int   fraction = (int)( (seconds_remaining - Mathf.Floor(seconds_remaining)) * 100);

    GetComponent<Text>().text = minutes.ToString("D2") + ":" + seconds.ToString("D2") + "." + fraction.ToString("D2");
  }
}
