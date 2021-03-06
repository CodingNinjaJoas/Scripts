﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public PlayerMovement p;
	public float waitBeforeSpawns;
	public float timeBetweenSpawns;
	public List<GameObject> enemies = new List<GameObject>();
	public List<GameObject> spawnPoints = new List<GameObject>();
	private void Start()
	{
		InvokeRepeating("Spawn",waitBeforeSpawns,timeBetweenSpawns);
	}
	private void Spawn()
	{
		if (p.gamePause == false)
		{
			if (p.gamePauseN == false)
			{
				int i = UnityEngine.Random.Range(0, spawnPoints.Count);
				GameObject g = Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count - 1)], spawnPoints[i].transform);
				if (g == null)
				{
					return;

				}
				g.transform.position = spawnPoints[i].transform.position;
			}
		}
	}
}
