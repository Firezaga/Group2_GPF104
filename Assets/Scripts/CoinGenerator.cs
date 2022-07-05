using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{

    public GameObject coin;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    public float speedMultiplier;

    void Awake()
    {
        currentSpeed = minSpeed;
        Invoke("generateCoin", 2.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed < maxSpeed)
            currentSpeed += speedMultiplier;
    }

    void generateCoin()
    {
        GameObject CoinIns = Instantiate(coin, transform.position, transform.rotation);
        CoinIns.GetComponent<CoinScript>().CoinGenerator = this;
    }

    public void GenerateNext()
    {
        float randomWait = Random.Range(1.5f, 5f);
        Invoke("generateCoin", randomWait);
    }
}
