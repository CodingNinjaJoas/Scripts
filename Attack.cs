using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack : MonoBehaviour
{
    public GameObject HitFX;
    public GameObject ImpactPositionLeft;
    public GameObject ImpactPositionRight;
    public GameObject weaponColliderRight;
    public GameObject weaponColliderLeft;
    public float resetTime;
    public float triggerImpactFXDelay = 0.2f;
    public string boolToSetS;
    public float attackCoolDown;
    public float coolDown;
}
