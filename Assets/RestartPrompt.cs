using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPrompt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalState.restartPromptText = gameObject;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
