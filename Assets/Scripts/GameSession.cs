using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameSession : MonoBehaviour
{
    int totalPoints = 0;
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {

        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions> 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = totalPoints.ToString();
    }
    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            //TakeLife();
            Invoke("TakeLife", 1.5f);
        }
        else
        {
            Invoke("ResetGameSession", 1.5f);
            /*ResetGameSession();*/
        }
    }
    public void GetExtraLive()
    {
        if (playerLives > 0 && playerLives < 10)
        {
            playerLives++;
        }
    }
    public void ProcessPoints(int points)
    {
        totalPoints += points;
        scoreText.text = totalPoints.ToString();    
    }
     void TakeLife()
    {
        playerLives --;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        livesText.text = playerLives.ToString();
    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
