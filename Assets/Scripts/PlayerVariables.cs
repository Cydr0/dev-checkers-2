using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{

    public static int maxAP = 20;
    public static int currentAP;
    public static CharacterControllerGeneric unitSelected = new CharacterControllerGeneric();

    public static int currentPlayer = 0;
    static int numberOfPlayers = 2;

    public static int flagTile1 = 0;
    public static int flagTile2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentAP = maxAP;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAP <= 0)
        {
            nextTurn();
        }
    }

    public static void nextTurn()
    {
        currentPlayer++;
        if (currentPlayer >= numberOfPlayers)
        {
            currentPlayer = 0;
        }
        currentAP = maxAP;
    }
}