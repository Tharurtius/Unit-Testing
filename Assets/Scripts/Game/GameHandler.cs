using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private PlayerManager playerPrefab;
    
    public PlayerManager GetPlayer()
    {
        return Instantiate<PlayerManager>(playerPrefab);
    }
}
