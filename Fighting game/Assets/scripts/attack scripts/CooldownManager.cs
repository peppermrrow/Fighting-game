using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.UI;
using Unity.VisualScripting;
using UnityEngine;
internal class CooldownList
{
    internal int cooldownvalue { get; set; }
    internal float cooldowntime { get; set; }
    internal CooldownList(int cooldownvalue, float cooldowntime)
    {
        this.cooldownvalue = cooldownvalue;
        this.cooldowntime = cooldowntime;
    }

}
public class CooldownManager : MonoBehaviour
{
    internal readonly List<CooldownList> cooldowns = new List<CooldownList>();
    private Queue<CooldownList> remove = new Queue<CooldownList>();
    private bool isRemoveScheduled;
    // Start is called before the first frame update
    void Start()
    {
        AttackStart.cooldownAction += AddCooldown;
    }
    void Update()
    {
        foreach (CooldownList cooldown in cooldowns)
        {
            cooldown.cooldowntime -= Time.deltaTime;
            if (cooldown.cooldowntime < 0)
            {
                remove.Enqueue(cooldown);
                isRemoveScheduled = true;

            }
        }
    }
    private void LateUpdate()
    {
        if (isRemoveScheduled) //schedule removal so list doesn't get altered while checked
        {
            RemoveCooldown();
            isRemoveScheduled = false;
        }
    }

    private void AddCooldown(AttackDataStorage f, int value)
    {
        CooldownList newCooldown = new CooldownList(value, f.TotalCooldown);

        // Add it to the list (only those on cooldown)
        cooldowns.Add(newCooldown);
    }
    private void RemoveCooldown() //removes cooldown if the time is 0. specific method to not mess with the list
    {
        int totalremoval = remove.Count;
        for (int i = 0; i < totalremoval; i++)
        {
            CooldownList removed = remove.Dequeue();
            cooldowns.Remove(removed);
            Debug.Log($"special {removed.cooldownvalue} is off cooldown");
        }
    }

}
