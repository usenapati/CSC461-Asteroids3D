using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    
    public static int highScore = 0;
    public static int points = 0;
    public static int level = 0;
    public static bool levelEndless = false;
    public static bool levelPassed = false;
    public static bool startReset = false;
    public static bool endOfGame = false;
    public static bool onMenu = true;
    public static int timer = 500;
    public static AsteroidSpawner asteroidSpawner;
    public static int currentID = 0;
    public static bool collided = false;
    public static bool ranOut = false;
    public static bool gameIsPaused = false;

    private void Awake()
    {
        asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
        FindObjectOfType<UIManager>().hidePaused();
        FindObjectOfType<UIManager>().hideGameOver();
        FindObjectOfType<UIManager>().showUI();
    }

    void Update()
    {
        PauseGame();
    }

    private void FixedUpdate()
    {
        //Debug.Log("Points: " + points);
        EndGame();
    }

    // Controls the end game sequence
    void EndGame()
    {
        // If collided or ran out of time, display game over screen
        if (collided || ranOut)
        {
            // DisplayGameOver
            FindObjectOfType<UIManager>().hidePaused();
            FindObjectOfType<UIManager>().showGameOver();
            FindObjectOfType<UIManager>().hideUI();
            //Debug.Log("GAME OVER");

        }
        // If finished the game, display success screen
        else
        {
            // DisplaySuccess
        }
        // DisplayPoints
        // DisplayHighScore
        // LevelSelection: Retry or Back to Main Menu
        
        
    }

    void Restart()
    {
        /**
        if (retrySelected)
        {
            if (!Globals.levelEndless)
            {
                //Globals.level = 0;
                Globals.timer = 500;
                asteroidSpawner.SpawnAsteroids();
            }
            Globals.endOfGame = false;
            Globals.levelPassed = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Globals.onMenu = true;
        }
        */
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            //Debug.Log("PAUSED");
            //Display Pause Menu
            FindObjectOfType<UIManager>().showPaused();
            FindObjectOfType<UIManager>().hideUI();
            Time.timeScale = 0f;
            // Pause Audio
        }
        else
        {
            //Debug.Log("UNPAUSED");
            //Hide Pause Menu
            FindObjectOfType<UIManager>().hidePaused();
            FindObjectOfType<UIManager>().showUI();
            Time.timeScale = 1f;
            // Unpause Audio
        }
    }

}
