using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScripts
{
    private GameHandler _gameHandler;
    private PlayerManager player;
    private GameObject enemy;
    [SetUp]
    public void Setup()
    {
        GameObject gameHandler = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game Handler"));
        _gameHandler = gameHandler.GetComponent<GameHandler>();
        player = _gameHandler.GetPlayer();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(player.gameObject);
        Object.Destroy(_gameHandler.gameObject);
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]//test player movement
    public IEnumerator PlayerMovement()
    {
        ushort testsComplete = 0;
        float initialPos = player.transform.position.x;
        //test left movement
        player.Move(Vector2.left); 
        
        yield return null;

        if (player.transform.position.x < initialPos)
        {
            testsComplete++;
        }
        //test right movement
        initialPos = player.transform.position.x;

        player.Move(Vector2.right);

        yield return null;

        if (player.transform.position.x > initialPos)
        {
            testsComplete++;
        }
        //test up movement
        initialPos = player.transform.position.y;

        player.Move(Vector2.up);

        yield return null;

        if (player.transform.position.y > initialPos)
        {
            testsComplete++;
        }
        //test down movement
        initialPos = player.transform.position.y;

        player.Move(Vector2.down);

        yield return null;

        if (player.transform.position.y < initialPos)
        {
            testsComplete++;
        }

        Assert.AreEqual(testsComplete, 4);
    }
    [UnityTest]//test if enemy contact lowers hp
    public IEnumerator HP()
    {
        enemy = _gameHandler.GetEnemy();
        float maxHP = player.hitpoints;
        enemy.transform.position = player.transform.position;
        yield return new WaitForSeconds(0.1f);
        Assert.Less(player.hitpoints, maxHP);
    }
    [UnityTest]//test if experience orbs increase player experience
    public IEnumerator Exp()
    {
        float startingExp = player.experience;
        player.transform.position = Vector3.zero;
        GameObject exp = _gameHandler.GetExperience();
        yield return new WaitForSeconds(0.1f);
        Assert.Greater(player.experience, startingExp);
    }
    [UnityTest]//test if bullet destroys enemy
    public IEnumerator Bullet()
    {
        enemy = _gameHandler.GetEnemy();
        GameObject bullet = _gameHandler.GetBullet();
        bullet.transform.position = enemy.transform.position;
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(enemy == null);
    }
}
