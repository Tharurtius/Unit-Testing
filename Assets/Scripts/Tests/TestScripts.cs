using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScripts
{
    private GameHandler _gameHandler;
    private PlayerManager player;
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
    [UnityTest]
    public IEnumerator PlayerMovesLeft()
    {
        float initialXPos = player.transform.position.x;

        player.Move(Vector2.left); 
        
        yield return null;

        Assert.Less(player.transform.position.x, initialXPos);
    }
    [UnityTest]
    public IEnumerator PlayerMovesRight()
    {
        float initialXPos = player.transform.position.x;

        player.Move(Vector2.right); 
        
        yield return null;

        Assert.Greater(player.transform.position.x, initialXPos);
    }
    [UnityTest]
    public IEnumerator PlayerMovesUp()
    {
        float initialYPos = player.transform.position.y;

        player.Move(Vector2.up); 
        
        yield return null;

        Assert.Greater(player.transform.position.y, initialYPos);
    }
    [UnityTest]
    public IEnumerator PlayerMovesDown()
    {
        float initialYPos = player.transform.position.y;

        player.Move(Vector2.down); 
        
        yield return null;

        Assert.Less(player.transform.position.y, initialYPos);
    }
}
