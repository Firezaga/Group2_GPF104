using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public ObstacleGenerator obstacleGenerator;

    [SerializeField]
    private int obsScore;
    private int obsMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * obstacleGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Next"))
        {
            obstacleGenerator.GenerateNext();
        }
        if (collision.gameObject.CompareTag("EndLine"))
        {
            Destroy(this.gameObject);
            obstacleGenerator.obsAddScore();
        }
    }
}
