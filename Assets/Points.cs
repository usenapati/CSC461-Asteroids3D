using UnityEngine;

public class Points : MonoBehaviour
{
    
    int highScore = 0;
    int points = 0;
    bool endOfGame = false;
    //int level = some_level_checker;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Points: " + points);
    }

    // Update is called once per frame
    void Update()
    {
        // The following is testing for points
        if (points == 0)
        {
            points += 100;
        } else
        {
            points += 25;
        }
        
        System.Random random = new System.Random();
        int endIt = random.Next(11);
        if (endIt == 10)
        {
           endOfGame = true;
        }
        else
        {
            endOfGame = false;
        }
        
        Debug.Log("Points:     " + points);
        Debug.Log("High Score: " + highScore);
        
        
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
                    points += 500;
                } 
                else if (asteroid.level == 2)
                {
                    points += 250;
                }
                else if (asteroid.level == 1)
                {
                    points += 100
                }
                asteroid.level -= 1;
            }
        }
        
        if (some_level_passed_checker)
        {
            int levelBonus = level * 2500;
            int timeBonus = timer * 10;
            // Display both         
            points += (levelBonus + timeBonus)
        }
        
        endOfGame = some_end_of_game_checker
        */
        
        if (endOfGame)
        {
            if (points > highScore)
            {
                highScore = points;
            }
            points = 0;
        }
        
    }
}
