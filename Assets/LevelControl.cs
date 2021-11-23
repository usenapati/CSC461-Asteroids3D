using UnityEngine;

public class LevelControl : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Globals.levelPassed = false;
        if (DummyAsteroidChecker() == 1)
        {
            Globals.level += 1;
            Globals.levelPassed = true;
        }
        if (Globals.level == 3)
        {
            Globals.endOfGame = true;
            Globals.level = 0;
        }
        
    }
    
    int DummyAsteroidChecker()
    {
        // return asteroidArray.length
        System.Random random = new System.Random();
        return random.Next(50);
    }
}
