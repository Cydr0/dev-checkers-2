using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{

    public static int maxAP = 20;
    public static int currentAP;
    public static CharacterControllerGeneric unitSelected;

    public static int currentPlayer = 0;
    static int numberOfPlayers = 2;

    // Start is called before the first frame update
    void Start(){
        currentAP = maxAP;
    }

    // Update is called once per frame
    void Update(){
        if(currentAP <= 0){
            nextTurn();
        }
    }

    public static void nextTurn(){
        currentPlayer++;
        if (currentPlayer >= numberOfPlayers){
            currentPlayer = 0;
        }
        currentAP = maxAP;
    }
}
