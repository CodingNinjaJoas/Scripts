﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpdaterFimble : MonoBehaviour
{
    public List<GameObject> hearts = new List<GameObject>();
    public float localHealth;
    public FimbleDore player;
    public void Update()
    {


        localHealth = player.health;
        if (localHealth <= 0)
        {
            player.Die();
            return;
        }
        foreach (GameObject h in hearts)
        {
            if (hearts.IndexOf(h) >= localHealth)
            {
                h.SetActive(false);
            }
            else
            {
                h.SetActive(true);
            }
        }
    }
}
