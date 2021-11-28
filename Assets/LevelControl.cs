using UnityEngine;

public class LevelControl : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (!Globals.levelEndless)
        {
            if (!Globals.endOfGame)
            {
                if (Globals.startReset)
                {
                    Globals.levelPassed = true;
                    LevelTransition();
                }
                else
                {
                    Globals.levelPassed = false;
                }
                
                if (DummyAsteroidChecker() == 1)
                {
                    if (Globals.level == 3)
                    {
                        Globals.levelPassed = true;
                        Globals.endOfGame = true;
                        Globals.level = 0;
                    }
                    else
                    {
                        Globals.levelPassed = true;
                    }
                }
                if (Globals.collided)
                {
                    Globals.endOfGame = true;
                }
            }
            else
            {
                EndGame(Globals.collided);
            }
        }
        else
        {
            if (!Globals.endOfGame)
            {
                if (Globals.collided)
                {
                    Globals.endOfGame = true;
                }
            }
            else
            {
                EndGame(Globals.collided);
            }
        }
    }
    
    int DummyAsteroidChecker()
    {
        // return asteroidArray.length
        System.Random random = new System.Random();
        return random.Next(50);
    }
    
    void LevelTransition()
    {
        // DisplayPoints
        Globals.timer = 500;
        Globals.level += 1;
        Globals.startReset = false;
        Globals.levelPassed = false;
    }
    
    void EndGame(bool collided)
    {
        if (collided)
        {
            // DisplayGameOver
        }
        else
        {
            // DisplaySuccess
        }
        // DisplayPoints
        // DisplayHighScore
        // LevelSelection
    }
        
}
