using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int scoreCount = 0;
    public GameObject score;
    public Rigidbody2D rb;
    public Rigidbody2D gun;
    public Vector2 bulletDirection;
    public GameObject bullet;
    public GameObject spawner;
    public GameObject enemy;
    public GameObject player;
    public float Force = 10.0f;
    public float offset = 0.6f;
    public GameObject bullet2;
    public GameObject deathScreen;

    private float shootCooldown = 0.2f;
    private float lastShootTime;
    void FixedUpdate()
    {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newshoot = (MousePosition - new Vector3(rb.position.x,rb.position.y,0)).normalized;
        float angle = Mathf.Atan2(newshoot.y,newshoot.x) * Mathf.Rad2Deg - 90;
        gun.rotation = angle;
        gun.position = rb.position + new Vector2(newshoot.x,newshoot.y).normalized * offset;
        bulletDirection = newshoot;

        if (System.Math.Abs(transform.position.x) > 26)
        {
            transform.position = new Vector2((int)(transform.position.x * -1), transform.position.y);
        }

        if (System.Math.Abs(transform.position.y) > 16)
        {
            transform.position = new Vector2(transform.position.x, (int)(transform.position.y * -1));
        }

        if (Input.anyKey)
        {
            rb.velocity = Vector2.zero;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity += new Vector2(0.0f, Force);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity += new Vector2(0.0f, -Force);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity += new Vector2(-Force, 0.0f);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity += new Vector2(Force, 0.0f);
            }
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
            {
                rb.velocity = new Vector2(Force, Force).normalized * Force;
            }
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
            {
                rb.velocity = new Vector2(Force, -Force).normalized * Force;
            }
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
            {
                rb.velocity = new Vector2(-Force, Force).normalized * Force;
            }
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
            {
                rb.velocity = new Vector2(-Force, -Force).normalized * Force;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastShootTime >= shootCooldown)
            {            
                    bullet2 = Instantiate(bullet, rb.position, Quaternion.identity);
                    bullet2.GetComponent<Rigidbody2D>().velocity = bulletDirection.normalized * 3f * Force;

                    lastShootTime = Time.time;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            deathScreen.SetActive(true);
            score.GetComponent<TextMeshProUGUI>().text = "Score: " + scoreCount.ToString();
            spawner.GetComponent<EnemySpawner>().KillPlayer();
            enemy.GetComponent<EnemyM>().KillPlayer();
            CircleAttackScore.SetScore(scoreCount);
            player.SetActive(false);

        }
    }

    public void updateScore()
    {
        scoreCount += 5;
        score.GetComponent<TextMeshProUGUI>().text = "Score: " + scoreCount.ToString();
    }
}
