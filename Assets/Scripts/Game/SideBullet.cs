using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBullet : MonoBehaviour
{
    public bool MoveRight;
    public float speed;
    public float lifetime;
    public float damage;
    public int pierce;

    // Update is called once per frame
    private void Start()
    {
        if (!MoveRight)
        {
            speed *= -1;
        }
    }

    void Update()
    {
        Vector2 pos = Vector2.zero;
        pos.x = speed * Time.deltaTime;
        transform.position += (Vector3)pos;
        lifetime -= Time.deltaTime;
        if (pierce <= 0)
        {
            lifetime = 0;
        }
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
