using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPrompt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalState.quitPromptText = gameObject;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
