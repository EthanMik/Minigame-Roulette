using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public float amplitude;
    public float frequency;
    Vector2 initialPosition;

    public SpriteRenderer spriteRenderer;
    public Material checkpointTaken;
    public GameObject levelEnd;

    public bool isInvisible;

    [System.Obsolete]
    private void Start()
    {
        initialPosition = transform.position;

        if (isInvisible)
            levelEnd.SetActive(false);
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(initialPosition.x, initialPosition.y + Mathf.Sin(Time.time * frequency) * amplitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.material = checkpointTaken;
    }
}
