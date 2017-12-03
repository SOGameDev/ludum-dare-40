using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    float score = 0;
    foreach ( GameObject present in GameObject.FindGameObjectsWithTag("Present") )
    {
      //if ( present.GetComponent<Present>().scorable )
      {
        score += present.GetComponent<Rigidbody2D>().mass * 25;
      }
    }

    Text score_text = GameObject.Find("Score").GetComponent<Text>();
    score_text.text = score.ToString();
  }
}
