using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{

    public static int maxAP = 20;
    public static int currentAP;
    // Start is called before the first frame update
    void Start()
    {
        currentAP = maxAP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
