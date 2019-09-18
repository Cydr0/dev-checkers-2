using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{

    public static int maxAP = 20;
    public static int currentAP;
    public static CharacterControllerGeneric unitSelected = new CharacterControllerGeneric();
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
