using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private PlayerManager playerPrefab;
    public GameObject enemyPrefab;
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
        return Instantiate<PlayerManager>(playerPrefab);
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
