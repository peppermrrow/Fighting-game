using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDataStorage : MonoBehaviour 
{
    [SerializeField] private int startup = 3;
    [SerializeField] private int activeframes = 1;
    [SerializeField] private int endlag = 5; // in frames
    [SerializeField] private float totalcooldown = 5; // in seconds
    [SerializeField] private int damage = 50;
    [SerializeField] private float hitstun = 0.5f;
    [SerializeField] private int knockback = 10;
    public int Startup
    {
        get { return startup; }
    }
    public int Activeframes
    {
        get { return activeframes; }
    }
    public int Endlag 
    { 
        get { return endlag; } 
    }
    public float TotalCooldown
    {
        get { return totalcooldown; }
    }
    public int Damage
    {
        get { return damage; }
    }
    public float Hitstun
    { 
        get { return hitstun; } 
    }
    public int Knockback
    {
        get { return knockback; } 
    }
}
