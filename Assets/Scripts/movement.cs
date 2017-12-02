using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

  public  Rigidbody2D  possessed_object;

  private Vector2      last_position;
  private Vector2      target;
  private float        speed = 250.0f;

  void Start () {
    target = possessed_object.position;
  }

  void FixedUpdate () {
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
}
