using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public GameObject MainMenu; 
    public GameObject GameOverMenu;
    public string gameOverSceneName = "GameOverMenu";
    public TextMeshProUGUI soulsText;
    public AudioSource collisionSound; //Add audio source to play when player collides with obtsacle
    public AudioSource backgroundMusic; //Add audio source to play background music when play button is pressed
 
    //Method to enable the game over menu on obstacle collision
    private void OnEnable() {
        Player.onPlayerCollision += EnableGameOverMenu;
    }

    //Method to remove game over menu when scripts game object is disabled
    private void OnDisable() {
        Player.onPlayerCollision -= EnableGameOverMenu;

    }

    //Method to load the game over menu in scene manager
    public void EnableGameOverMenu() {

        //Load the gameOverMenu scene
        SceneManager.LoadScene(gameOverSceneName);

        //Deactivate the Main Menu scene
        MainMenu.SetActive(false);

        //Activate the Game Over Menu scene
        GameOverMenu.SetActive(true);

        //Save soul count before switching scenes
        Player player = FindObjectOfType<Player>();
            if (player != null) {
    
        PlayerPrefs.SetInt("SoulCount", player.GetSoulCount());
        PlayerPrefs.Save();

        //Toggle EventSystem based on the active menu
        GameObject eventSystem = GameObject.Find("EventSystem");
        
            if (eventSystem != null) {
            eventSystem.SetActive(GameOverMenu.activeSelf);
            }

            //Play the collision sound before switching scene
            if (collisionSound != null) {
                collisionSound.Play();
            }
        }
    }
    private void Start() {

    //Load souls in game-over menu
    if (soulsText != null)
    {
        int souls = PlayerPrefs.GetInt("SoulCount", 0);
        UpdateSouls(souls);
    }
}
    //Method to 'restart' and go back to playing the game
    public void PlayGame() {

        //When restart button is pressed, minus one in scene index to go back to game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("HITTING BUTTON");
    }

    public void backToMenu() {

        //When main menu button is pressed, minus two scenes to go back to main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    //Method to update the amount of souls collected and add it to a string displayed in the gameovermenu
    public void UpdateSouls(int souls) {
    
        soulsText.text = souls.ToString() + " SOULS COLLECTED";
    }
}


