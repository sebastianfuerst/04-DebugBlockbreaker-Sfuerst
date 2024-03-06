using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //constants
    private const string BREAKABLE = "Breakable";
    private const string UNBREAKABLE = "UnBreakable";

    //config params
    public AudioClip breakSound;
    public GameObject blockSparklesVFX;
    public Sprite[] hitSprites;

    //cached reference
    private Level level;
    private GameSession gameStatus;

    //state variables
    [SerializeField] int timesHit; //only for debug purposes

    private void Start()
    {
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameSession>();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if (tag == BREAKABLE)
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == BREAKABLE)
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        gameStatus.AddToScore();
        level.BlockDestroyed();
        TriggerSparkleVFX();
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparkleVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position.x, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
