using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int lives, score;

    [SerializeField]
    Text livesText,levelText, scoreText, nextLevelText;


    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    GameObject nextLevelPanel;

    public int numberOfBricks;

    [SerializeField]
    Transform[] levels;

    [SerializeField]
    int currentLevelIndex=0;

    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
        ball = FindObjectOfType<Ball>();

        
        LoadLevel();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeInLives)
    {
        // we can use increase and decrease for lives
        lives += changeInLives;
        if (lives <=0)
        {
            lives = 0;
            Invoke("GameOver", 1f);
        }
        livesText.text = "Lives: " + lives;
    }
    public void UpdateScore(int points)
    {
        score += points;

        scoreText.text = "Score: " + score;
    }
    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if (numberOfBricks <=0)
        {
            if (currentLevelIndex < levels.Length)
            {
                Invoke("OpenNextLevelPanel", 1f);
            }
            else
            {
                Invoke("GameOver", 1f);
            }

        }
    }
    public int GetLives()
    {
        return lives;
    }
    void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);        
    }
    void LoadLevel()
    {
        levelText.text = "Level " + (currentLevelIndex + 1);
        nextLevelPanel.SetActive(false);
        Instantiate(levels[currentLevelIndex].gameObject, transform.position, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
        currentLevelIndex++;
        

    }
    void OpenNextLevelPanel()
    {
        ball.GetComponent<Ball>().SetInPlay();
        Time.timeScale = 0;
        nextLevelPanel.SetActive(true);
        nextLevelText.text = "Next Level " + (currentLevelIndex + 1);
        
    }
    public void NextLevel()
    {        
        LoadLevel();
        Time.timeScale = 1;

    }
    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
