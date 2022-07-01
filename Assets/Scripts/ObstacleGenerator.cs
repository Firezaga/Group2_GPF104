using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstacle;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    public float speedMultiplier;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = minSpeed;
        generateObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed < maxSpeed)
            currentSpeed += speedMultiplier;
    }

    void generateObstacle()
    {
        GameObject ObstacleIns = Instantiate(obstacle, transform.position, transform.rotation);
        ObstacleIns.GetComponent<ObstacleScript>().obstacleGenerator = this;
    }

    public void GenerateNext()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateObstacle", randomWait);
    }
}
