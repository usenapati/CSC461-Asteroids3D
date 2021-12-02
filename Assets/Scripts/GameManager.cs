using UnityEngine;

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

    private void Awake()
    {
        asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
    }

    private void FixedUpdate()
    {
        //Debug.Log("Points: " + points);
    }
}
