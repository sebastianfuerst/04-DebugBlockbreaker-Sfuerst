using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //configruation parameters
    public float minX = 1f;
    public float maxX = 15f;
    public float screenWidthInUnits = 16f;

    //cached references
    GameSession theGameSession;
    Ball theBall;

	// Use this for initialization
	void Start ()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPosition(), minX, maxX);
        transform.position = paddlePos;
	}

    private float GetXPosition
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
