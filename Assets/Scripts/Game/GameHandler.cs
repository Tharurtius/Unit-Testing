using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private PlayerManager playerPrefab;
    public GameObject enemyPrefab;
    public GameObject expPrefab;
    public GameObject bulletPrefab;
    public float spawnCooldown;
    public float spawnCurrentCooldown;

    private void Update()
    {
        spawnCurrentCooldown -= Time.deltaTime;
        if (spawnCurrentCooldown <= 0)
        {
            spawnCurrentCooldown = spawnCooldown;
            SpawnEnemy();
        }
    }

    public PlayerManager GetPlayer()
    {
        return Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);
    }

    public GameObject GetEnemy()
    {
        return Instantiate(enemyPrefab, Vector2.zero, Quaternion.identity);
    }

    public GameObject GetExperience()
    {
        return Instantiate(expPrefab, Vector3.zero, Quaternion.identity);
    }

    public GameObject GetBullet()
    {
        return Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
    }

    public void SpawnEnemy()
    {
        Vector2 position = Vector2.zero;

        do
        {
            position.x = Random.Range(-10f, 10f);
            position.y = Random.Range(-10f, 10f);
        } while ((PlayerManager.playerPos - position).magnitude < 5);

        Instantiate(enemyPrefab, position, Quaternion.identity);
    }
}
