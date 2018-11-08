using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    SceneManager.Season currentSeason;

    [SerializeField]
    private Sprite winterSprite;
    [SerializeField]
    private Sprite springSprite;
    [SerializeField]
    private Sprite summerSprite;
    [SerializeField]
    private Sprite automnSprite;

    void Start()
    {
        currentSeason = SceneManager.instance.GetSeason();
    }

    void Update()
    {
        SceneManager.Season season = SceneManager.instance.GetSeason();

        if (season != currentSeason)
        {
            if (season == SceneManager.Season.winter)
                GetComponent<SpriteRenderer>().sprite = winterSprite;
            else if (season == SceneManager.Season.spring)
                GetComponent<SpriteRenderer>().sprite = springSprite;
            else if (season == SceneManager.Season.summer)
                GetComponent<SpriteRenderer>().sprite = summerSprite;
            else
                GetComponent<SpriteRenderer>().sprite = automnSprite;
        }
        currentSeason = season;
    }
}
