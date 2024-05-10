using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static Unity.VisualScripting.Member;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyFollower;
    public GameObject enemyCharger;
    public GameObject player;

    public int maxSpawnCount = 50;
    public float spawnInterval = 1f;
    public float spawnIntervalDecrease = -0.05f;
    public float chargerSpeedIncrease = 1f;
    public float minimumSpawnInterval = 0.2f;
    private int currentSpawnCount;

    public bool dead = false;

    void Start()
    {
        currentSpawnCount = 0;
        StartCoroutine(SpawnEnemys());
    }

    private void FixedUpdate()
    {
        if (dead)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Roulette");
    }

    IEnumerator SpawnEnemys()
    {
        while (!dead)
        {
            yield return new WaitForSeconds(spawnInterval);


            SpawnFollower();

            int picker = UnityEngine.Random.Range(1, 4);

            if (player.GetComponent<PlayerMovement>().scoreCount > 250 && picker == 1)
                SpawnCharger();

            currentSpawnCount++;

            if (currentSpawnCount % 10 == 0 && spawnInterval > minimumSpawnInterval)
            {
                spawnInterval += spawnIntervalDecrease;

                if (enemyCharger.GetComponent<EnemyCharge>().speed < 40 && player.GetComponent<PlayerMovement>().scoreCount > 400)
                    enemyCharger.GetComponent<EnemyCharge>().speed += chargerSpeedIncrease;
            }
        }
    }

    void SpawnFollower()
    {
        var enemyPosition = new Vector2((UnityEngine.Random.Range(0, 2) * 2 - 1) * 35, UnityEngine.Random.Range(-18, 18));
        Instantiate(enemyFollower, enemyPosition, Quaternion.identity).GetComponent<EnemyM>().isCloned = true;
    }

    void SpawnCharger()
    {
        int picker = UnityEngine.Random.Range(1, 3);
        Vector2 enemyPosition;

        if (picker % 2 == 0)
            enemyPosition = new Vector2((UnityEngine.Random.Range(0, 2) * 2 - 1) * 26, UnityEngine.Random.Range(-14, 15));
        else
            enemyPosition = new Vector2(UnityEngine.Random.Range(-25, 26), (UnityEngine.Random.Range(0, 2) * 2 - 1) * 15);

        Instantiate(enemyCharger, enemyPosition, Quaternion.identity).GetComponent<EnemyCharge>().isCloned = true;
    }

    public void KillPlayer()
    {
        dead = true;
    }
}
