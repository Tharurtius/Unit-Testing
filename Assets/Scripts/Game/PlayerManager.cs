using System.Collections;
using System.Collections.Generic;
using Codice.CM.Client.Differences;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = Vector2.zero;
        if (Input.GetAxis("Vertical") != 0)
        {
            move.y = Input.GetAxis("Vertical");
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            move.x = Input.GetAxis("Horizontal");
        }
        
        Move(move);
    }

    public void Move(Vector2 input)
    {
        gameObject.transform.position += (Vector3)input * Time.deltaTime * speed;
    }
}
