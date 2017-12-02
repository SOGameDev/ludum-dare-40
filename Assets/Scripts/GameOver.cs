using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
  public GameObject game_over_ui;

  private Timer timer;
  private bool  time_up = false;

	void Start () {
    game_over_ui.SetActive(false);
    timer = GameObject.Find( "Timer" ).GetComponent<Timer>();
    timer.timerEnd += new EventHandler( TimerEndHandler );
	}

	void Update () {
    if ( time_up )
    {
      if ( Input.GetButtonDown("Start") )
      {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
      }
    }
	}

  void TimerEndHandler ( object _, EventArgs __ ) {
    game_over_ui.SetActive(true);
    time_up = true;
  }
}
