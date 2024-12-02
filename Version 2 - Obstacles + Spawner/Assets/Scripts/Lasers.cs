using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    public float speed = 5f; //Up speed to up difficulty
    private float leftEdge; //Left edge of screen

    private void Start() {

        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update() {

        transform.position += Vector3.left * speed * Time.deltaTime;

        //If position is less than the position of the left edge, laser is destroyed. 
        if(transform.position.x < leftEdge - 4f) { //Added extra length because objects were deleting before going off-screen
            Destroy(gameObject);
        }
    }
}