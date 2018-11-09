using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float coolDown;
    [Header("Enemy Variables")]
    public float health = 50;
    public float damage =10;

    public virtual void Die(){}
}