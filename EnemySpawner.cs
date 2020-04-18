using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public float timeBetweenSpawns;
	public List<GameObject> enemies = new List<GameObject>();
	public List<GameObject> spawnPoints = new List<GameObject>();
	private void Start()
	{
		InvokeRepeating("Spawn",timeBetweenSpawns,timeBetweenSpawns);
	}
	private void Spawn()
	{
		int i = UnityEngine.Random.Range(0,spawnPoints.Count);
		GameObject g = Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count - 1)], spawnPoints[i].transform);
		if (g == null)
		{
			return;
		
		}
		g.transform.position = spawnPoints[i].transform.position;
	}
}
