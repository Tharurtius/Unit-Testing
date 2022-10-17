using System.Collections;
using System.Collections.Generic;
using Codice.CM.Client.Differences;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int speed;
    public float hitpoints;
    public float experience;
    public static Vector2 playerPos;
    public GameObject sideBullet;
    public float sideBulletCooldown;
    private float sideBulletCurrentCooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        sideBulletCurrentCooldown = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        //get controls and move
        Vector2 move = Vector2.zero;
        move.y = Input.GetAxis("Vertical");
        move.x = Input.GetAxis("Horizontal");
        Move(move);
        
        //move position back towards center of screen
        //Debug.Log(Camera.main.WorldToViewportPoint(transform.position));
        //Vector3 edge = Camera.main.WorldToViewportPoint(transform.position);
        //Vector3 initialPos = edge;
        //edge.x = Mathf.Clamp(edge.x, 0.1f, 0.9f);
        //edge.y = Mathf.Clamp(edge.y, 0.1f, 0.9f);
        ////Debug.Log(edge);
        //if (edge.x != initialPos.x || edge.y != initialPos.y)
        //{
        //    transform.position = Camera.main.ViewportToWorldPoint(edge);
        //}
        
        //static player position
        playerPos = transform.position;
        
        //fires side bullets on cooldown
        sideBulletCurrentCooldown -= Time.deltaTime;
        if (sideBulletCurrentCooldown <= 0)
        {
            sideBulletCurrentCooldown = sideBulletCooldown;
            FireLeftBullet();
            FireRightBullet();
        }
    }

    public void Move(Vector2 input)
    {
        gameObject.transform.position += (Vector3)input * Time.deltaTime * speed;
    }

    public void FireLeftBullet()
    {
        Instantiate(sideBullet, transform.position, Quaternion.identity);
    }

    public void FireRightBullet()
    {
        GameObject bullet = Instantiate(sideBullet, transform.position, Quaternion.identity);
        bullet.GetComponent<SideBullet>().MoveRight = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hitpoints -= 2 * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collide");
        if (collision.gameObject.tag == "Experience")
        {
            //Debug.Log("if tag");
            experience++;
            Destroy(collision.gameObject);
        }
    }
}
