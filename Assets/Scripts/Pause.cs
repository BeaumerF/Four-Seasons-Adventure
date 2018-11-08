using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    private static bool GameIsPaused = false;
    public GameObject Menu;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                GameResume();
            else
                GamePause();
        }
    }

    void GameResume()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);
        GameIsPaused = false;
    }

    void GamePause()
    {
        Time.timeScale = 0f;
        Menu.SetActive(true);
        GameIsPaused = true;
    }
}
