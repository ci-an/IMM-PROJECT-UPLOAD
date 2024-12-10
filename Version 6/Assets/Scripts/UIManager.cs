using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject MainMenu; 
    public GameObject GameOverMenu;
    public string gameOverSceneName = "GameOverMenu";
 
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
        SceneManager.LoadScene(gameOverSceneName);
        
        //Deactivate the Main Menu scene
         MainMenu.SetActive(false);

        //Activate the Game Over Menu scene
        GameOverMenu.SetActive(true);

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
}

