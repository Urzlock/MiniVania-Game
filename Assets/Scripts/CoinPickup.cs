using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int pointsValue = 100;
    [SerializeField] AudioClip sfx;
    void OnTriggerEnter2D(Collider2D collision)
    {
        bool wasCollected = false;
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            AudioSource.PlayClipAtPoint(sfx,Camera.main.transform.position,100);
            gameSession.ProcessPoints(pointsValue);
            Destroy(gameObject);
        }

    }
    
}
