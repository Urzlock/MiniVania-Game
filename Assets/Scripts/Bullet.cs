using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int pointsValue = 200;
    [SerializeField] float bulletSpeed = 1f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    GameSession gameSession;
    float xSpeed;
 
     void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
        gameSession = FindObjectOfType<GameSession>();
    }
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(xSpeed, 0f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemies")
        {
            Destroy(collision.gameObject);
            gameSession.ProcessPoints(pointsValue);
        }
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
