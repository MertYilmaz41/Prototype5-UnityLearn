using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float xRange = 4;
    private float ySpawnPos = 2;

    public int pointValue;

    private GameManager gameManager;
    private Rigidbody targetRigidBody;
    public ParticleSystem explosionParticle;

    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRigidBody = GetComponent<Rigidbody>();

        targetRigidBody.AddForce(RandomForce(), ForceMode.Impulse);
        targetRigidBody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position =  RandomSpawnPosition();
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
       
    }

    Vector3 RandomForce() 
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque() 
    {
        return Random.Range(-minSpeed, maxSpeed);
    }

    Vector3 RandomSpawnPosition() 
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
