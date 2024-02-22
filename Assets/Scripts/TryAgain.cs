using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TryAgain : MonoBehaviour
{
    public void OnTryAgainButtonClicked()
    {
        // Load the scene that the player was in when they reached the game over screen
        SceneManager.LoadScene(PlayerPrefs.GetInt("GameOverScene"));
    }
}
