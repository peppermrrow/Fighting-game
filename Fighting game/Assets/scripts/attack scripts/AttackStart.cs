using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaitForRealTime : CustomYieldInstruction //yield instruction for more robust calculations (not frame dependent)
{
    private float targetFrameCount;
    private float currentTimeCount;

    public WaitForRealTime(int frames)
    {
        targetFrameCount = frames / 60; //targetFrameCount is in 0.01666 seconds steps, not in actual frames.
        currentTimeCount = 0;
    }


    public override bool keepWaiting
    {
        get
        {
            currentTimeCount += Time.deltaTime;
            return currentTimeCount < targetFrameCount;
        }
    }
}
[RequireComponent(typeof(BoxCollider))]
public class AttackStart : MonoBehaviour
{
    [SerializeField] private AttackDataStorage framedata;
    [SerializeField] private int instance;
    private static Action extraAction;
    public static Action<AttackDataStorage, int> cooldownAction;
    BoxCollider boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        framedata = GetComponent<AttackDataStorage>();
        boxCollider.enabled = false;
    }
    private void OnEnable()
    {
        StartCoroutine(AttackFrameData());
        
    }
    private IEnumerator AttackFrameData() // basic functionality for the attack. add extra logic where necessary. do *NOT* add the attack logic here directly, instead reference a script with the logic. (some logic handled here as a template for now)
    {
        yield return new WaitForRealTime(framedata.Startup); 
        boxCollider.enabled = true;
        //attack logic
        yield return new WaitForRealTime(framedata.Activeframes);
        boxCollider.enabled = false;
        yield return new WaitForRealTime(framedata.Endlag);
        cooldownAction?.Invoke(framedata, instance);
        gameObject.SetActive(false);
        yield break;
    }
}


