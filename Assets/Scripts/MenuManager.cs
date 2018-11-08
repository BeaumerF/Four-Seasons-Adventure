using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    private SceneSwitcher _switcher = null;

    void Start()
    {
        _switcher = SceneSwitcher.instance;
    }

    public void ToGame()
    {
        _switcher.GoToScene("DiscoverLevel");
    }

    public void ToExit()
    {
        _switcher.ExitGame();
    }

    public void ToMenu()
    {
        _switcher.GoToScene("Menu");
    }
}
