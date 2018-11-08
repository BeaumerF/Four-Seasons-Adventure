using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour {

    public static SceneSwitcher instance = null;
    private int NbCoin;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

	public void GoToScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetCoins(int number)
    {
        NbCoin = number;
    }

    public int GetCoins()
    {
        return NbCoin;
    }
}
