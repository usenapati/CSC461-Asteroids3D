using UnityEngine;

public class Points : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (!Globals.levelEndless)
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
            
            if (Globals.levelPassed)
            {
                int levelBonus = Globals.level * 2500;
                int timeBonus = Globals.timer * 10;            
                // Display both         
                Globals.points += (levelBonus + timeBonus);
                Debug.Log(timeBonus);
                Globals.startReset = true;            
            }
        }
        else
        {        
            if (Globals.endOfGame)
            {
                if (Globals.points > Globals.highScore)
                {
                    Globals.highScore = Globals.points;
                }
                Globals.points = 0;
            }
        }
        
    }
}
