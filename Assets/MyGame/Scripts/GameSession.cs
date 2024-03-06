using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Include this for TextMeshProUGUI

public class GameSession : MonoBehaviour // Inherit from MonoBehaviour
{
    // Config parameters
    [Range(0.1f, 10f)] public float gameSpeed = 1f;
    public int pointsPerBlockDestroyed = 83;
    public TextMeshProUGUI scoreText; // Ensure you have imported the TMP package and assigned this in the Unity Editor
    public bool isAutoPlayEnabled;

    // State variables
    public int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
