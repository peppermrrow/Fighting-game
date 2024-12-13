using UnityEngine;
using System.Collections.Generic;
using System;

public class InputCheck : MonoBehaviour
{
    private HashSet<KeyCode> activeKeys = new HashSet<KeyCode>();
    private Dictionary<KeyCode, int> keyValues;
    public static int keyCombinations = 0;
    public HitboxToggler toggler;
    public static Action leftClick;

    void Start()
    {
        keyValues = new Dictionary<KeyCode, int>
        {
            { KeyCode.Z, 1 },
            { KeyCode.X, 2 },
            { KeyCode.C, 4 },
            { KeyCode.V, 8 },
            { KeyCode.E, 16 },
            { KeyCode.R, 32 },
            { KeyCode.F, 64 }
        };
        if (toggler == null)
        {
            toggler = GetComponent<HitboxToggler>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        { 
            leftClick?.Invoke();
        }
        UpdateActiveKeys();
    }

    private void UpdateActiveKeys()
    {
        foreach (KeyCode key in keyValues.Keys)
        {
            if (Input.GetKeyDown(key))
            {
                activeKeys.Add(key); 
                HandleKeyCombinations(); 

            }
            if (Input.GetKeyUp(key))
            {
                activeKeys.Remove(key); 
                HandleKeyCombinations(); 
            }
            
        }
    }

    private void HandleKeyCombinations()
    {
        foreach (KeyCode key in activeKeys)
        {
            if (keyValues.ContainsKey(key))
            {
                keyCombinations += keyValues[key];
                if (keyValues[key] < 10)
                {
                    toggler.hitboxtoggler(keyCombinations);
                    
                }
            }
        }
        keyCombinations = 0; // resets to 0 because the function shares any meaningful data before it resets
    }
}
