using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration parameters
    public float minX = 1f;
    public float maxX = 15f;
    public float screenWidthInUnits = 16f;

    // Cached references
    private GameSession theGameSession;
    private Ball theBall;

    // Use this for initialization
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        if (theGameSession == null)
        {
            Debug.LogError("GameSession not found in the scene!");
        }

        theBall = FindObjectOfType<Ball>();
        if (theBall == null)
        {
            Debug.LogError("Ball not found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPosition(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPosition()
    {
        if (theGameSession != null && theGameSession.IsAutoPlayEnabled())
        {
            return theBall != null ? theBall.transform.position.x : transform.position.x; // Fallback to current position if null
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
