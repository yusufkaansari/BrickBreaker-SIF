using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(string name)
    {
        Debug.Log("New Level Loaded"+ name);
        SceneManager.LoadScene(name);
    }
    public void QuitRequest()
    {
        Debug.Log("Quit Requested");
        Application.Quit();
    }
    public void BrickDestroyed()
    {
        if (BlockController.breakableNumber<=0)
        {
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
        BlockController.breakableNumber = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
