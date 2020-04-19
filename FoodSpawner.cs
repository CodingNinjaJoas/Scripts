using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public List<Transform> foodsSpawnPoint = new List<Transform>();
    public List<GameObject> foods = new List<GameObject>();
    public float spawnRate;
    public float food;
    public PlayerMovement player;
    private void Start()
    {
        InvokeRepeating("SpawnFood",spawnRate,spawnRate);
    }
    private void SpawnFood()
    {
        if (player.gamePauseN == false)
        {
            if (player.gamePause == false)
            {
                if (food == 0)
                {
                    int i = UnityEngine.Random.Range(0, foodsSpawnPoint.Count - 1);
                    food++;
                    GameObject g = Instantiate(foods[UnityEngine.Random.Range(0, foods.Count - 1)], foodsSpawnPoint[i]);
                    g.transform.position = foodsSpawnPoint[i].transform.position;
                }
            }
        }
    }
}
