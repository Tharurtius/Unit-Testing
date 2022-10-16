using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private PlayerManager player;
    [SerializeField] private float maxHP;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
        player = FindObjectOfType<PlayerManager>();
        maxHP = player.hitpoints;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = player.hitpoints / maxHP;
    }
}
