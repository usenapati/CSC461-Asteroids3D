using UnityEngine;

public class LevelControl : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // If not on the menu
        if (!Globals.onMenu)
        {
            // If playing level-based
            if (!Globals.levelEndless)
            {
                // If the game is ongoing
                if (!Globals.endOfGame)
                {
                    // If we are going to the next level
                    if (Globals.startReset)
                    {
                        // Make sure the level doesn't progress while setting up next level
                        Globals.levelPassed = true;
                        LevelTransition();
                    }
                    else
                    {
                        Globals.levelPassed = false;
                    }
                    
                    // If all the asteroids have been destroyed, start level transition
                    if (Globals.asteroidArray.Length == 0)
                    {
                        if (Globals.level == 3)
                        {
                            Globals.endOfGame = true;
                        }
                        Globals.levelPassed = true;
                    }
                    // If the spaceship has collided with an asteroid, end the game
                    if (Globals.collided)
                    {
                        Globals.endOfGame = true;
                    }
                }
                // Initiate end game sequence
                else
                {
                    EndGame();
                }
            }
            // If playing endless
            else
            {
                if (!Globals.endOfGame)
                {
                    // Pretty much only check if the spaceship has collided
                    if (Globals.collided)
                    {
                        Globals.endOfGame = true;
                    }
                }
                else
                {
                    EndGame();
                }
            }
        }
        else
        {
            /*
            if (endlessSelected)
            {
                Globals.levelEndless = true;
            }
            else
            {
                Globals.levelEndless = false;
            }
            Globals.onMenu = false;            
            */
        }
    }
    
    // Sets up the next level
    void LevelTransition()
    {
        // DisplayPoints
        Globals.timer = 500;
        Globals.level += 1;
        Globals.startReset = false;
        Globals.levelPassed = false;
    }
    
    // Controls the end game sequence
    void EndGame()
    {
        // If collided or ran out of time, display game over screen
        if (Globals.collided || Globals.ranOut)
        {
            // DisplayGameOver
        }
        // If finished the game, display success screen
        else
        {
            // DisplaySuccess
        }
        // DisplayPoints
        // DisplayHighScore
        // LevelSelection: Retry or Back to Main Menu
        /**
        if (retrySelected)
        {
            if (!Globals.levelEndless)
            {
                Globals.level = 0;
                Globals.timer = 500;
            }
            Globals.endOfGame = false;
            Globals.levelPassed = false;
        }
        else
        {
            Globals.onMenu = true;
        }
        */
    }
        
}
