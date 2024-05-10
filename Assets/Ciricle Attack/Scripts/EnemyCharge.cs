using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharge : MonoBehaviour
{
    public GameObject enemyCharger;
    public Rigidbody2D rb;

    public Animation spawnAnim;


    public float speed = 6;
    public bool dead = false;
    private bool spawnAnimationPlayed = false;

    public Vector2 direction;

    public bool isCloned = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnAnim = GetComponent<Animation>();
    }

    void FixedUpdate()
    {
        if (System.Math.Abs(transform.position.x) > 33 || System.Math.Abs(transform.position.y) > 26)
        {
            Destroy(gameObject);
        }

        if (isCloned && !spawnAnimationPlayed)
        {
            StartCoroutine(SpawnAnimation());
        }
    }

    IEnumerator SpawnAnimation()
    {
        spawnAnim.Play("EnemySpawn");
        spawnAnimationPlayed = true;

        do
        {
            yield return null;
        }
        while (spawnAnim.IsPlaying("EnemySpawn"));

        Vector2 velocity = direction * speed;
        rb.velocity = velocity;

        gameObject.tag = "Enemy";

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Left"))
        {
            direction = Vector2.left;
        }

        if (collision.gameObject.CompareTag("Right"))
        {
            direction = Vector2.right;
        }

        if (collision.gameObject.CompareTag("Up"))
        {
            direction = Vector2.up;
        }

        if (collision.gameObject.CompareTag("Down"))
        {
            direction = Vector2.down;
        }

    }
}
