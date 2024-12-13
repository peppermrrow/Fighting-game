using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public BoxCollider BoxCollider;
    private AttackDataStorage data;
    // Start is called before the first frame update
    void Awake()
    {
        BoxCollider = GetComponent<BoxCollider>();
        BoxCollider.enabled = false;
        data = GetComponent<AttackDataStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    internal void attack()
    {
        BoxCollider.enabled = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy")&& other.gameObject != this.gameObject) 
        {
            
        }
    }
    private void logic(Collider other)
    {
        PlayerStats player = other.GetComponent<PlayerStats>();
        if (player == null)
        {
            return;
        }
        AttackDataStorage stats = GetComponentInParent<AttackDataStorage>();
        player.Hp -= stats.Damage;
        player.activatestun(stats.Hitstun);

    }
}
