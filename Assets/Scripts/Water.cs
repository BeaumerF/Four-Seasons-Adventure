using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    SceneManager.Season currentSeason;

    [SerializeField]
    private Sprite winterSprite;
    [SerializeField]
    private Sprite waterSprite;

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
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<SpriteRenderer>().sprite = winterSprite;
                GetComponent<BoxCollider2D>().enabled = true;
            }
            else if (season == SceneManager.Season.autumn || season == SceneManager.Season.spring)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<SpriteRenderer>().sprite = waterSprite;
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        currentSeason = season;
    }
}
