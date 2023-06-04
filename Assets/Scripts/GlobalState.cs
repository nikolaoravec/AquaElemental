using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class GlobalState : MonoBehaviour
{
    public static GameObject gameOverText;
    public static GameObject restartPromptText;
    public static GameObject quitPromptText;
    public static bool gameOver = false;

    public GameObject player;

    public static int coinCount = 0;

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && gameOver)
        {
            NewGame(); return;
        }
        if (Input.GetKeyUp(KeyCode.Q) && gameOver)
        {
            Debug.Log("Q KEY");
            Application.Quit(); return;
        }
    }
   
    public void Start()
    {
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
        quitPromptText.SetActive(true);
    }

    public void NewGame()
    {
        gameOver = false;
        gameOverText.SetActive(false);
        restartPromptText.SetActive(false);
        quitPromptText.SetActive(false);
        coinCount = 0;
        Instantiate(player);
    }
}