using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class GlobalState : MonoBehaviour
{
    public static GameObject gameOverText;
    public static GameObject restartPromptText;
    public static bool gameOver = false;

    public GameObject player;

    public static int coinCount = 0;

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && gameOver)
        {
            NewGame();
        }
    }
   
    public void Start()
    {
        gameOverText.SetActive(false);
        restartPromptText.SetActive(false);
    }

    public static void SetGameOverText(GameObject obj)
    {
        Debug.Log("setting object");
        gameOverText = obj;
    }

    public static void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        restartPromptText.SetActive(true);
    }

    public void NewGame()
    {
        gameOver = false;
        gameOverText.SetActive(false);
        restartPromptText.SetActive(false);
        coinCount = 0;
        Instantiate(player);
    }

    public void OnKeyDown(KeyDownEvent ev)
    {
        Debug.Log("on key down " + ev.keyCode);
        if (ev.keyCode == KeyCode.Space) NewGame();
    }
}