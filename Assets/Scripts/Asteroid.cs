using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Asteroid : MonoBehaviour
{
    Rigidbody rb;

    public float initialForce = 10f;
    public float initialTorque = 10f;

    public float health;
    public int size;
    private int id;
    
    public Asteroid(int initSize)
    {
        size = initSize;
        id = GameManager.currentID;
        GameManager.currentID++;
        //LARGE
        if (size == 2)
        {
            health = 5;
        }
        //MEDIUM
        else if (size == 1)
        {
            health = 2;
        }
        //SMALL
        else
        {
            health = 1;
        }
    }
    
    public Asteroid()
    {
        id = GameManager.currentID;
        GameManager.currentID++;
        //LARGE
        if (size == 2)
        {
            health = 5;
        }
        //MEDIUM
        else if (size == 1)
        {
            health = 2;
        }
        //SMALL
        else
        {
            health = 1;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        rb.AddForce(Vector3.forward * initialForce);
        rb.AddTorque(Vector3.forward * initialTorque);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.endOfGame)
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

    public void TakeDamage(float damage)
    {
        health -= damage;

        Debug.Log($"Taking damage, new health at {health}");

        if (health <= 0)
        {
            Destroyed();
        }
    }
    
    void Destroyed()
    {
        // Split each asteroid into two other asteroids if it is big enough
        if (size == 2)
        {
            GameManager.points += 500;
            GameManager.asteroidSpawner.SpawnAsteroid(this.transform.position, 1);
            Destroy(this.gameObject);
            //GameManager.asteroidArray[id] = new Asteroid(1);
            //GameManager.asteroidArray[GameManager.currentID] = new Asteroid(1);
        }
        else if (size == 1)
        {
            GameManager.points += 250;
            GameManager.asteroidSpawner.SpawnAsteroid(this.transform.position, 0);
            Destroy(this.gameObject);
            //GameManager.asteroidArray[id] = new Asteroid(0);
            //GameManager.asteroidArray[GameManager.currentID] = new Asteroid(0);
        }
        else
        {
            GameManager.points += 100;
            Destroy(this.gameObject);
            //GameManager.asteroidArray[id] = null;
        }
    }
    
    void CollisionChecker()
    {
        //if distance(spaceship, asteroid) < ##
        //{
        //  Globals.collided = true;  
        //
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            Debug.Log("Collided with Player");
            // Subtract Player's Life
            //If Game is Over
            GameManager.collided = true;
            GameManager.endOfGame = true;
            FindObjectOfType<ShipMovement>().enabled = false;    
            FindObjectOfType<ShipShooting>().enabled = false;    
        }
    }

    private void OnDestroy()
    {
        //Instantiate Destruction Particles
        //Play Explosion SFX
    }

}
