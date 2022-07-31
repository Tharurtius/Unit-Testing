using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float speed;
    public float hitpoints;
    public GameObject exp;
    void Update()
    {
        Vector3 direction = (PlayerManager.playerPos - (Vector2)transform.position).normalized;//direction
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 position = transform.position + direction * speed * Time.deltaTime;
        rb.MovePosition(position);

        if (hitpoints <= 0)
        {
            Instantiate(exp, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            SideBullet bullet = collision.gameObject.GetComponent<SideBullet>();
            bullet.pierce--;
            hitpoints -= bullet.damage;
        }
    }
}
