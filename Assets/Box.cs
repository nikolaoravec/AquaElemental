using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Box created");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * 5.0f) * Time.deltaTime;
    }

    public void DestroyGameObject()
    {
        Debug.Log("destroy triggered");
        Destroy(gameObject);
    }
}
