using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float speed;
    void FixedUpdate()
    {
        Vector3 direction = (PlayerManager.playerPos - (Vector2)transform.position).normalized;//direction
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 position = transform.position + direction * speed * Time.deltaTime;
        rb.MovePosition(position);
    }
}
