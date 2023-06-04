using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("collide " + other.gameObject.name);
        Destroy(other.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("trigger " + other.gameObject.name);
        Destroy(other.gameObject);
    }
}