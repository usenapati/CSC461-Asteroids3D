using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private int health;
    private int size;
    private int id;
    
    public Asteroid(int initSize)
    {
        size = initSize;
        id = Globals.currentID;
        Globals.currentID++;
        if (size == 2)
        {
            health = 5;
        }
        else if (size == 1)
        {
            health = 2;
        }
        else
        {
            health = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Globals.endOfGame)
        {
            CollisionChecker();
            bool hit = false;
            // bool hit = HitChecker();
            if (hit)
            {
                health -= 1;
            }
            if (health <= 0)
            {
                Destroyed();
            }
        }
    }
    
    void Destroyed()
    {
        // Split each asteroid into two other asteroids if it is big enough
        if (size == 2)
        {
            Globals.points += 500;
            Globals.asteroidArray[id] = new Asteroid(1);
            Globals.asteroidArray[Globals.currentID] = new Asteroid(1);
        }
        else if (size == 1)
        {
            Globals.points += 250;
            Globals.asteroidArray[id] = new Asteroid(0);
            Globals.asteroidArray[Globals.currentID] = new Asteroid(0);
        }
        else
        {
            Globals.points += 100;
            Globals.asteroidArray[id] = null;
        }
    }
    
    void CollisionChecker()
    {
        //if distance(spaceship, asteroid) < ##
        //{
        //  Globals.collided = true;  
        //
    }
    
}
