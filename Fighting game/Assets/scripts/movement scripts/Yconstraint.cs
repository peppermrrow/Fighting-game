using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yconstraint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure the pivot only rotates around the Y axis, if needed
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
