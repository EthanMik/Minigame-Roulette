using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class EventManager : MonoBehaviour
{
    public Rigidbody2D rb;

    private Vector2 checkpointLocation;
    private Checkpoint checkpoint;
    Animation deathAnimation;
    public Renderer playerRenderer;

    public Material playerColor;
    public Material transparent;

    public Movement movement;
    public Jumping jumping;

    [System.Obsolete]
    private void Start()
    {
        checkpoint = FindObjectOfType<Checkpoint>();
        deathAnimation = GetComponent<Animation>();
 
    }

    private void FixedUpdate()
    {
        float playerYCoord = transform.position.y;

        if (playerYCoord < -9 || playerYCoord > 7) 
        {
            transform.position = checkpointLocation;
        }
        checkpointLocation = checkpoint.GetCheckpointLocation();
    }
    IEnumerator DeathAnimation()
    {
        deathAnimation.Play("Player Death");
        movement.enabled = false;
        jumping.enabled = false;

        do
        {
            yield return null;
        }
        while (deathAnimation.IsPlaying("Player Death"));

        playerRenderer.material = playerColor;
        transform.position = checkpointLocation;
        movement.enabled = true;
        jumping.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Danger"))
        {
            rb.velocity = Vector2.zero;
            playerRenderer.material = transparent;
            StartCoroutine(DeathAnimation());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Easy"))
        {
            SceneManager.LoadScene("Shape Run Easy");
        }
        if (collision.gameObject.CompareTag("Hard"))
        {
            SceneManager.LoadScene("Shape Run");
        }
    }
}
