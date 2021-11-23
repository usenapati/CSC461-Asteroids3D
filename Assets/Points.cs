using UnityEngine;

public class Points : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
        Globals.timer -= 1;
        if (Globals.timer == 0)
        {
            Globals.endOfGame = true;
        }
        
        // The following is testing for points
        if (Globals.points == 0)
        {
            Globals.points += 100;
        } else
        {
            Globals.points += 25;
        }
        
        //Debug.Log("Points:     " + Globals.points);
        //Debug.Log("High Score: " + Globals.highScore);
        //Debug.Log("Level: " + Globals.level);
        //Debug.Log("Timer: " + Globals.timer);
        
        
        // The following is the planned code to implement
        /*
        asteroid = some_collision_checker;
        
        if (asteroid != null)
        {
            asteroid.health -= 1;
            
            if (asteroid.health == 0)
            {
                if (asteroid.level == 3)
                {
                    Globals.points += 500;
                } 
                else if (asteroid.level == 2)
                {
                    Globals.points += 250;
                }
                else if (asteroid.level == 1)
                {
                    Globals.points += 100
                }
                asteroid.level -= 1;
            }
        }
        
        */
        
        if (Globals.levelPassed)
        {
            int levelBonus = Globals.level * 2500;
            int timeBonus = Globals.timer * 10;            
            // Display both         
            Globals.points += (levelBonus + timeBonus);
            Debug.Log(timeBonus);
            ResetLevel();
            
        }
        
        if (Globals.endOfGame)
        {
            if (Globals.points > Globals.highScore)
            {
                Globals.highScore = Globals.points;
            }
            Globals.points = 0;
        }
        
    }
    
    void ResetLevel()
    {
        Globals.timer = 500;
    }
}
