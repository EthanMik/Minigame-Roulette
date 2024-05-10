using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerMovement player;

    [System.Obsolete]
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        if (System.Math.Abs(transform.position.x) > 28 || System.Math.Abs(transform.position.y) > 21)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            player.GetComponent<PlayerMovement>().updateScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
