using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    // parameters
    [SerializeField] int breakableBlocks; //Serialized for debugging purposes

    //cached references
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            LoadEndScreen();
        }
    }

    private void LoadEndScreen()
    {
        if (sceneLoader.IsLastPlayScene)
        {
            sceneLoader.LoadCongrats();
        }
        else
        {
            sceneLoader.LoadNextScene();
        }
    }
}
