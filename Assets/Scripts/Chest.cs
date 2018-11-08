using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public GameObject givenObject;
    private bool open = false;
    public Sprite OpenSprite;
    public Sprite CloseSprite;
    private SpriteRenderer CurrentChest;
    public Transform spawnPoint;
    private Animator animator;

    // Start
    void Start()
    {
        CurrentChest = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        //ChangeSprite();
    }

    // Change Sprite
    private void ChangeSprite()
    {
        if (open)
        {
            CurrentChest.sprite = OpenSprite;
        }
        else
        {
            CurrentChest.sprite = CloseSprite;
        }
    }

    // Is Open
    public bool CanOpen()
    {
        return !open;
    }

    // Open Chest
    public void OpenChest()
    {
        if (CanOpen())
        {
            open = true;
            animator.SetBool("open", true);
            Instantiate(givenObject, spawnPoint.position, spawnPoint.rotation);
            //ChangeSprite();
        }
    }
}
