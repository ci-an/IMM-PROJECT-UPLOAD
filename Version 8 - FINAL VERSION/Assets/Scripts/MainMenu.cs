using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

   //Method to play the game (button)
   public void PlayGame() {

      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   //Method to quit the game (button)
   public void QuitGame() {

      Debug.Log("QUIT GAME");
      Application.Quit();
   }
   //Method to open github (button)
   public void OpenGithub() {

      Application.OpenURL("https://github.com/ci-an/IMM-PROJECT-UPLOAD/tree/main");
   }
}
