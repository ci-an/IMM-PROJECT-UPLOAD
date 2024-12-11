using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isGameOver; //Boolean variable to see whether the game has ended or is ongoing
    private Vector3 direction; //Declare direction varaible to move
    public float gravityModifier = -10.0f; //Initialize gravityModifier variable to apply gravity on player
    public float updraft = 5.0f; //Initialize updraft variable to push against gravity
    public AudioSource jumpSound; //Add audio source varaible to play a jump sound
    public AudioSource collisionSound; //Add audio source to play when player collides with obtsacle
    public AudioSource scoringSound; //Add audio for when the player collects a soul
    public AudioSource backgroundMusic; //Add audio for background music
    private Rigidbody playerRigid;
    public static event Action onPlayerCollision; //Static event to call on when player collides with obstacle
    private int soulCount = 0; //Track number of souls collided with

    private void Start() {

        //Get rigid body component from <RigidBody>
        playerRigid = GetComponent<Rigidbody>();

        //Apply a small amount of updraft at the start of game
        playerRigid.AddForce(Vector3.up * 4, ForceMode.Impulse);

        //Stop the jump sound if it has been played already
        if (jumpSound.isPlaying) {
            jumpSound.Stop();
        }
        //Stop the collision sound if its being played already
        if (collisionSound.isPlaying) {
            collisionSound.Stop();
        }
        //Ensure background music starts if it's not already playing
        if (backgroundMusic != null && !backgroundMusic.isPlaying) {
            backgroundMusic.Play();
        }
    }

    private void Update() {
        //If space is pressed, jump
        if(Input.GetKeyDown(KeyCode.Space)) {
            direction = Vector3.up * updraft;

            //Play the jump sound if it is assigned
            if (jumpSound != null) {
                jumpSound.Stop(); //Stop current sound
                jumpSound.Play(); //Play jump sound
            }
        }
        //Apply gravity on every frame
        direction.y += gravityModifier * Time.deltaTime;

        //Update players position using rigidbody component
        playerRigid.velocity = new Vector3(0, direction.y, 0);
    }

    //Method to detect collision with obstacles
    private void OnCollisionEnter(Collision collision) {
    Debug.Log("Trigger Entered with: " + collision.gameObject.name);

    if(collision.gameObject.tag == "Obstacle") {
        Debug.Log("Hit an obstacle!");
        if (collisionSound != null && !collisionSound.isPlaying)
            {
                collisionSound.Play(); //Play audio for collision with obstacle
            }
        //Check if game is over, invoke player collision and change scene
        FindObjectOfType<GameState>().isGameOver();
        onPlayerCollision?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } 
    }
    //Method to detect collision with souls
    private void OnTriggerEnter(Collider other) {
    
        //Check if the collided object is tagged as "Scoring"
        if(other.CompareTag("Scoring")) {
            //Increment soul count variable
            soulCount++;
            Debug.Log($"Soul collected! Total souls: {soulCount}");

            //Save the updated soul count to PlayerPrefs to use in UIManager to get total souls at end of game
            PlayerPrefs.SetInt("SoulCount", soulCount);
            PlayerPrefs.Save();

            //Play the scoring sound
            if (scoringSound != null)
            {
                scoringSound.Play();
            }
            //Destroy the soul object
            Destroy(other.gameObject);    
        }
    }
    //Method to keep count of souls
    public int GetSoulCount() {
        return soulCount;
    }
}

