using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource impactSound;

    void onCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0.5f)
        {
            impactSound.Play();
        }
    }
}
