using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class PlayerStats : MonoBehaviour
{
    private int hp = 1000;
    private int maxhp = 1000;
    private bool stunned = false;
    public int Hp
    {
        get { return hp; }
        set
        {
            if (hp < 0) { hp = 0; }
            else if (hp > maxhp) { hp = maxhp; }
            hp = value;
            
        }
    }
    public bool Stunned
    {
        get { return stunned; }
        private set { stunned = value; }
    }
    private void Start()
    {
        
    }
    public IEnumerator activatestun(float time)
    {
        Stunned = true;
        yield return new WaitForSeconds(time);
        Stunned = false;
    }
}
