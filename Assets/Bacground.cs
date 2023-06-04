using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacground : MonoBehaviour
{
    public GameObject bubbles;
    private float bubbleSpawnDeadline = 0f;
    private float bubbleSpawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bubbleSpawnTimer < bubbleSpawnDeadline) {
            bubbleSpawnTimer += Time.deltaTime;
        } else {
            System.Random rand = new System.Random();

            var randX = (float)rand.Next(5) + (float)rand.NextDouble();
            if (rand.Next() % 2 == 0) randX = -randX;
            
            var randY = (float)rand.Next(5) + (float)rand.NextDouble();
            if (rand.Next() % 2 == 0) randY = -randY;

            Vector3 pos = new Vector3(transform.position.x + randX, transform.position.y + randY, 0);
            
            Instantiate(bubbles, pos, Quaternion.identity);

            bubbleSpawnTimer = 0f;
            bubbleSpawnDeadline = (float)rand.Next(1,2) + (float)rand.NextDouble();
        }
    }
}
