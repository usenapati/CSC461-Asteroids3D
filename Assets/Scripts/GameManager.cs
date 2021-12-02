using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    public static int endlesshighScore = 0;
    public static int levelhighScore = 0;
    public static string bestTime;
    public static int points = 0;
    public static int level = 0;
    public static bool levelEndless = false;
    public static bool levelPassed = false;
    public static bool startReset = false;
    public static bool endOfGame = false;
    public static bool onMenu = true;
    public static AsteroidSpawner asteroidSpawner;
    public static int currentID = 0;
    public static bool collided = false;
    public static bool ranOut = false;
    public static bool gameIsPaused = false;
    public static bool retrySelected = false;


    private void Awake()
    {
        asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
        FindObjectOfType<UIManager>().hidePaused();
        FindObjectOfType<UIManager>().hideGameOver();
        FindObjectOfType<UIManager>().showUI();
        if (levelEndless)
        {
            FindObjectOfType<StopWatch>().StartStopWatch();
        }
        else
        {
            FindObjectOfType<Timer>().StartTimer();
        }


    }

    void Update()
    {
        PauseGame();
        Restart();
    }

    private void FixedUpdate()
    {
        if (!levelEndless && !FindObjectOfType<Timer>().GetTimerActive() || FindObjectOfType<Timer>().GetCurrentTime() <= 0)
        {
            ranOut = true;
        }
        //Debug.Log("Points: " + points);
        EndGame();
    }

    // Controls the end game sequence
    void EndGame()
    {
        // If collided or ran out of time, display game over screen
        if (collided || ranOut)
        {
            endOfGame = true;
            // DisplayGameOver
            if (levelEndless)
            {
                FindObjectOfType<StopWatch>().StopStopWatch();
            }
            else
            {
                FindObjectOfType<Timer>().StopTimer();
            }
            if (levelEndless && points > endlesshighScore)
            {
                endlesshighScore = points;
                bestTime = FindObjectOfType<StopWatch>().PrintCurrentTime();
            }
            else if (!levelEndless && points > levelhighScore)
            {
                levelhighScore = points;
                bestTime = FindObjectOfType<Timer>().PrintCurrentTime();
            }

            FindObjectOfType<UIManager>().hideUI();
            FindObjectOfType<UIManager>().showGameOver();
            FindObjectOfType<ShipMovement>().enabled = false;
            FindObjectOfType<ShipShooting>().enabled = false;
            //Debug.Log("GAME OVER");

        }
        // If finished the game, display success screen
        else
        {
            // DisplaySuccess if level is complete
            if (!levelEndless && points > levelhighScore)
            {
                levelhighScore = points;
                bestTime = FindObjectOfType<Timer>().PrintCurrentTime();
            }
        }
        // DisplayPoints
        // DisplayHighScore
        // LevelSelection: Retry or Back to Main Menu


    }

    void Restart()
    {

        if (retrySelected)
        {
            foreach (Transform child in asteroidSpawner.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            asteroidSpawner.SpawnAsteroids();
            if (levelEndless)
            {
                FindObjectOfType<StopWatch>().ResetStopWatch();
                FindObjectOfType<StopWatch>().StartStopWatch();
            }
            else
            {
                FindObjectOfType<Timer>().ResetTimer();
                FindObjectOfType<Timer>().StartTimer();
                level = 0;
            }
            points = 0;
            endOfGame = false;
            levelPassed = false;
            collided = false;
            ranOut = false;
            retrySelected = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else
        {
            //onMenu = true;
        }
    }

    void PauseGame()
    {
        if (gameIsPaused && !endOfGame)
        {
            //Debug.Log("PAUSED");
            //Display Pause Menu
            FindObjectOfType<UIManager>().showPaused();
            FindObjectOfType<UIManager>().hideUI();
            Time.timeScale = 0f;
            // Pause Audio
        }
        else if (!gameIsPaused && !endOfGame)
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
