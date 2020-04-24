using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;

    
    private Rigidbody enemyRigidbody;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameObject.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {

        // Subtract enemy position from player position to get the
        // direction enemy should move towards the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        Vector3 awayFromCliff = (new Vector3(0, 0, 0) - transform.position).normalized;
        
        // Move back to center if near edge
        if (transform.position[0] > 9 || transform.position[0] < -9 || transform.position[2] > 9 || transform.position[2] < -9)
        {
            enemyRigidbody.AddForce(awayFromCliff  * 6.0f);
        } else
        {
            // Move the enemy towards the player based off a set speed
            enemyRigidbody.AddForce(lookDirection * speed);
        }
        
        if(transform.position.y < -1)
        {
            Destroy(gameObject);
        }
    }
}
