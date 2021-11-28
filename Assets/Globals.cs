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
    public static int timer = 500;
    public static int[] asteroidArray = new int[10];
    public static bool collided = false;
}
