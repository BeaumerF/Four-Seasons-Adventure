using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTile : MonoBehaviour {

    SceneManager.Season currentSeason;

    [SerializeField]
    private bool winter;
    [SerializeField]
    private bool spring;
    [SerializeField]
    private bool autumn;
    [SerializeField]
    private bool summer;

    // Use this for initialization
    void Start () {
        currentSeason = SceneManager.instance.GetSeason();
    }
	
	// Update is called once per frame
	void Update () {
        SceneManager.Season season = SceneManager.instance.GetSeason();

        if (season != currentSeason)
        {
            if (season == SceneManager.Season.winter)
            {
                GetComponent<SpriteRenderer>().enabled = winter;
                GetComponent<BoxCollider2D>().enabled = winter;
            }
            else if (season == SceneManager.Season.autumn)
            {
                GetComponent<SpriteRenderer>().enabled = autumn;
                GetComponent<BoxCollider2D>().enabled = autumn;
            }
            else if (season == SceneManager.Season.spring)
            {
                GetComponent<SpriteRenderer>().enabled = spring;
                GetComponent<BoxCollider2D>().enabled = spring;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = summer;
                GetComponent<BoxCollider2D>().enabled = summer;
            }
        }
        currentSeason = season;
    }
}
