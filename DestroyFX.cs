using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFX : MonoBehaviour
{
    public bool destroyFX = true;
  
    void Start()
    {
        if (destroyFX == true)
        {
            Destroy(this.gameObject, 4);
        }
    }

  
}
