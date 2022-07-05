using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public CoinGenerator CoinGenerator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * CoinGenerator.currentSpeed * Time.deltaTime);
        if (transform.position.x < -50)
        {
            CoinGenerator.GenerateNext();
            Destroy(this.gameObject);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Next"))
        {
            CoinGenerator.GenerateNext();
        }
        if (collision.gameObject.CompareTag("EndLine"))
        {
            Destroy(this.gameObject);
        }
    }
}
