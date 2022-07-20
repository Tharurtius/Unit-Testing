using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScripts
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PlayerMovesRight()
    {


        GameObject gameHandler = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game Handler"));

        PlayerManager player = gameHandler.GetComponent<GameHandler>().GetPlayer();

        float initialXPos = player.transform.position.x;

        player.Move(Vector2.right); 
        
        yield return new WaitForSeconds(0.1f);

        Assert.Greater(player.transform.position.x, initialXPos);
        
        
        //Object Destroy(GameHandler)
    }
}
