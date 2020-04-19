using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleUpdaterUI : MonoBehaviour
{
    public int index;
    public int amountOpen;
    public ShopManager s;
    public List<GameObject> closed = new List<GameObject>();
    public List<GameObject> opened = new List<GameObject>();

    void Update()
    {
        if (s.upsBought[index] > amountOpen)
        {
            closed[amountOpen].SetActive(false);
            opened[amountOpen].SetActive(true);
            amountOpen++;
        }
    }
}
