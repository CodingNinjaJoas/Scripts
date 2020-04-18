using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public PlayerMovement p;
    public GameObject outline;
    public FoodSpawner f;
    private void OnMouseEnter()
    {
        outline.SetActive(true);
    }
    private void OnMouseExit()
    {
        outline.SetActive(false);
    }
    private void OnMouseDown()
    {
        f.food--;
        p.food++;
        Destroy(this.gameObject);
    }
}
