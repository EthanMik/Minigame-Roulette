using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyM : MonoBehaviour
{
    public GameObject m_Enemy;
    public GameObject m_Player;
    public Rigidbody2D rb;
    public Rigidbody2D Player;
    public float Force = 5;
    public bool dead = false;
    public bool isCloned = false;


    private void Start()
    {
        Force = Random.Range(3, 8);
    }

    void FixedUpdate()
    {
        if (!dead && isCloned)
        {
            rb.velocity = new Vector2(Player.position.x - rb.position.x, Player.position.y - rb.position.y).normalized * Force;
        }
        else if (dead)
        {
            rb.velocity = Vector2.zero;
        }

    }

    public void KillPlayer()
    {
        dead = true;
    }
}
