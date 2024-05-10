using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public float amplitude;
    public float frequency;
    Vector2 initialPosition;

    public SpriteRenderer spriteRenderer;
    public Material checkpointTaken;

    public Vector2 checkpointLocation = new(2, -3);

    public bool isCheckpointActive = false;

    public GameObject levelEnd;

    private void Start()
    {
        isCheckpointActive = false;
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(initialPosition.x, initialPosition.y + Mathf.Sin(Time.time * frequency) * amplitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelEnd.SetActive(true);
        spriteRenderer.material = checkpointTaken;
        checkpointLocation = new Vector2(initialPosition.x, initialPosition.y);
    }

    public Vector2 GetCheckpointLocation()
    {
        return checkpointLocation;
    }

    public bool IsCheckpointActive()
    {
        return isCheckpointActive;
    }
}
