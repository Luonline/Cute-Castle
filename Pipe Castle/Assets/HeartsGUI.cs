﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsGUI : MonoBehaviour {

    public Sprite heartEmpty, heartFull;
    public GameObject[] hearts;

    public int numHearts;

	// Use this for initialization
	void Start () {
        UpdateHearts();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Updates the display to show the number of hearts the player has
    void UpdateHearts()
    {

        if(numHearts == 0)
        {
            hearts[0].GetComponent<SpriteRenderer>().sprite = heartEmpty;
            hearts[1].GetComponent<SpriteRenderer>().sprite = heartEmpty;
            hearts[2].GetComponent<SpriteRenderer>().sprite = heartEmpty;
        } else if(numHearts == 1)
        {
            hearts[0].GetComponent<SpriteRenderer>().sprite = heartFull;
            hearts[1].GetComponent<SpriteRenderer>().sprite = heartEmpty;
            hearts[2].GetComponent<SpriteRenderer>().sprite = heartEmpty;
        } else if(numHearts == 2)
        {
            hearts[0].GetComponent<SpriteRenderer>().sprite = heartFull;
            hearts[1].GetComponent<SpriteRenderer>().sprite = heartFull;
            hearts[2].GetComponent<SpriteRenderer>().sprite = heartEmpty;
        } else
        {
            hearts[0].GetComponent<SpriteRenderer>().sprite = heartFull;
            hearts[1].GetComponent<SpriteRenderer>().sprite = heartFull;
            hearts[2].GetComponent<SpriteRenderer>().sprite = heartFull;
        }
    }

    public void IncreaseHeart()
    {
        if(numHearts <= 3)
        {
            numHearts++;
            UpdateHearts();
        }
    }

    public void DecreaseHeart()
    {
        if(numHearts > 0)
        {
            numHearts--;
            UpdateHearts();
        }
    }
}
