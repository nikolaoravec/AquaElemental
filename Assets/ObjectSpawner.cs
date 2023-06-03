using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject spawnableObject;

    private float timer;
    private int spawnTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < spawnTime) {
            timer += Time.deltaTime;
        } else {
            System.Random rand = new System.Random();
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + (float)rand.Next(2) + (float)rand.NextDouble(), 0);
            
            Instantiate(spawnableObject, pos, Quaternion.identity);
            timer = 0;
            spawnTime = rand.Next(1,3);
        }

    }
}
