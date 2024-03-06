using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Ensure this is included for Unity-specific functionality

public class Ball : MonoBehaviour
{
    // Configuration parameters
    public Paddle paddle1; // Ensure this is assigned in the Unity Editor
    public float xPush = 2f;
    public float yPush = 15f;
    public AudioClip[] ballSounds; // Populate this array in the Unity Editor
    public float randomFactor = 0.2f;

    // State
    private Vector2 paddleToBallVector;
    private bool hasStarted = false;

    // Cached component references
    private AudioSource myAudioSource;
    private Rigidbody2D myRigidBody2D;

    void Start()
    {
        // Calculate the initial position difference between ball and paddle
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>(); // Ensure an AudioSource component is attached to this GameObject
        myRigidBody2D = GetComponent<Rigidbody2D>(); // Ensure a Rigidbody2D component is attached to this GameObject
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        // Launch the ball on mouse click
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        // Keep the ball positioned relative to the paddle before launch
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Add a random velocity tweak to the ball on collision if the game has started
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)]; // Ensure ballSounds is not empty
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
