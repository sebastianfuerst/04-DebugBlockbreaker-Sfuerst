using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private const string GAMEOVERSCREEN = "GameOver";
    private const string CONGRATSSCREEN = "Congrats";
    private const string LEVEL5 = "Level5";

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadWelcome()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(GAMEOVERSCREEN);
    }

    public void LoadCongrats()
    {
        SceneManager.LoadScene(CONGRATSSCREEN);
    }

    public bool IsLastPlayScene()
    {
        // Compare the name of the current active scene with LEVEL5
        return SceneManager.GetActiveScene().name == LEVEL5;
    }
}
