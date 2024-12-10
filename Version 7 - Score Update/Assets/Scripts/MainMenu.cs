using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

   public void PlayGame() {

      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void QuitGame() {

      Debug.Log("QUIT GAME");
      Application.Quit();
   }

   public void OpenGithub() {

      Application.OpenURL("https://github.com/ci-an/IMM-PROJECT-UPLOAD/tree/main");
   }
}
