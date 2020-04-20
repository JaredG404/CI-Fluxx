using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {
    public void MainMenu () {
        SceneManager.LoadScene ("MainMenu");
    }
    public void QuitGame () {
        Debug.Log ("Quit Game.");
        Application.Quit ();
    }
}