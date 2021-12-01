using UnityEngine;

public class Globals : MonoBehaviour
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
    public static Asteroid[] asteroidArray = new Asteroid[50];
    public static int currentID = 0;
    public static bool collided = false;
    public static bool ranOut = false;
}
