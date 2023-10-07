using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int lives, score;

    [SerializeField]
    Text livesText, scoreText;
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeInLives)
    {
        // we can use increase and decrease for lives
        lives += changeInLives;

        livesText.text = "Lives: " + lives;
    }
    public void UpdateScore(int points)
    {
        score += points;

        scoreText.text = "Score: " + score;
    }
}
