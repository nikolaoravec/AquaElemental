using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    public GameObject objectPrefab;

    private float timer = 0;
    private int spawnTime = 0;

    private void Start()
    {

    }

    private void Update()
    {
        if (timer < spawnTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            System.Random rand = new System.Random();

            // Generate a random number between 1 and 3 to determine the number of objects to instantiate
            int numObjectsToInstantiate = rand.Next(1, 4);

            for (int i = 0; i < numObjectsToInstantiate; i++)
            {
                // Generate a random position offset for each object
                float offsetX = rand.Next(0, 3); // Random value between 0 and 2 for X position offset
                float offsetY = rand.Next(0, 3); // Random value between 0 and 2 for Y position offset

                Vector3 spawnPosition = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, 0);

                Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            }

            timer = 0;
            spawnTime = rand.Next(3, 5);
        }
    }

}
