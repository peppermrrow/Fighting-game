using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxToggler : MonoBehaviour
{
    private List<GameObject> hitboxes = new List<GameObject>();
    private Dictionary<int, GameObject> hitboxMap;
    CooldownManager cooldownList;
    PlayerStats stunCheck;
    // Start is called before the first frame update
    void Start()
    {
        stunCheck = GetComponentInParent<PlayerStats>();
        cooldownList = GetComponent<CooldownManager>();
        foreach (Transform hitbox in this.transform.GetComponentsInChildren<Transform>())
        {
            if (hitbox == this.transform)
            {
                continue;
            }
            hitboxes.Add(hitbox.gameObject);
            Debug.Log("added " + hitbox.gameObject.name);
            hitbox.gameObject.SetActive(false);
        }
        if (hitboxes != null)
        {
            hitboxMap = new Dictionary<int, GameObject>
            {
                { 1, hitboxes[4] },   // Z
                { 2, hitboxes[5] },   // X
                { 4, hitboxes[6] },   // C
                { 8, hitboxes[7] },   // V
                { 17, hitboxes[8] }, // E + Z
                { 18, hitboxes[9] }, // E + X
                { 20, hitboxes[10] }, // E + C
                { 24, hitboxes[11] }  // E + V
            };
        }
        else
        {
            Debug.LogError("no dictionary. gameobject list is null");
        }
        InputCheck.leftClick += leftclicktoggler;
    }

    private void leftclicktoggler()
    {
        hitboxes[0].SetActive(true);
    }
    internal void hitboxtoggler(int value)
    {
        // Check if the hitboxreference exists in the dictionary
        if (hitboxMap.TryGetValue(InputCheck.keyCombinations, out GameObject hitbox) && stunCheck.Stunned != false)
        {
            bool allowed = true;
            foreach (CooldownList cooldown in cooldownList.cooldowns)
            {
                
                if (cooldown.cooldownvalue < hitboxes.Count && hitboxes[cooldown.cooldownvalue]?.gameObject == hitbox )
                {
                    allowed = false;
                    Debug.Log($"attack {hitbox} is on cooldown.");
                    break;
                }
                else if (cooldown.cooldownvalue >= hitboxes.Count || hitboxes[cooldown.cooldownvalue] == null)
                {
                    Debug.LogWarning("issue with hitbox in reference to cooldownvalue");
                }

            }
            if (allowed)
            {
                hitbox.SetActive(true); // Activate the corresponding hitbox
                Debug.Log("hitbox " + hitbox.name + " enabled");
            }
        }
    }
}
