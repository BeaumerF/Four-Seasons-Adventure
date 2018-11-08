using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public static SceneManager instance = null;
    public enum Season {winter, spring, summer, autumn};
    private Season currentSeason;

	void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        currentSeason = Season.spring;
    }

	void Update () {
		
	}

    public void GoToHome()
    {
        Time.timeScale = 1f;
        SceneSwitcher.instance.GoToScene("Menu");
    }

    public void GoToExit()
    {
        Application.Quit();
    }

    public Season GetSeason()
    {
        return (currentSeason);
    }

    public void SetWinter()
    {
        this.currentSeason = Season.winter;
    }

    public void SetSpring()
    {
        this.currentSeason = Season.spring;
    }

    public void SetSummer()
    {
        this.currentSeason = Season.summer;
    }

    public void SetAutumn()
    {
        this.currentSeason = Season.autumn;
    }
}
