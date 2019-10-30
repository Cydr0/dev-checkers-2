using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{

    public static int maxAP = 20;
    public static int currentAP;
    public static CharacterControllerGeneric unitSelected = new CharacterControllerGeneric();

    public static CharacterControllerRobot[] playerOneCharacters;
    public static CharacterControllerAlien[] playerTwoCharacters;

    public static int currentPlayer = 0;
    static int numberOfPlayers = 2;

    public static int flagTile1 = 0;
    public static int flagTile2 = 0;

    public static int goalTile1 = 0;
    public static int goalTile2 = 0;

    static bool hasFlag1 = false;
    static bool hasFlag2 = false;

    public static bool showFlag1 = true;
    public static bool showFlag2 = true;

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

    public static void player1HasFlag(){
        hasFlag1 = true;
        showFlag2 = false;
    }

    public static void player1DroppedFlag(int tile)
    {
        hasFlag1 = false;
        showFlag2 = true;
        flagTile2 = tile;

        Vector3 pos = TerrainHandler.cells[flagTile2].transform.position;
        pos.y += 0.3f;
        LevelHandler.flagP2.transform.position = pos;
    }

    public static void player2HasFlag()
    {
        hasFlag2 = true;
        showFlag1 = false;
    }

    public static void player2DroppedFlag(int tile)
    {
        hasFlag2 = false;
        showFlag1 = true;
        flagTile1 = tile;

        Vector3 pos = TerrainHandler.cells[flagTile1].transform.position;
        pos.y += 0.3f;
        LevelHandler.flagP1.transform.position = pos;
    }

    public static void setPlayerOneCharacters(int[] units){
        playerOneCharacters = new CharacterControllerRobot[units.Length];
        for(int i = 0; i < units.Length; i++){
            playerOneCharacters[i].createCharacter(units[i]);
        }
    }

    public static void setPlayerTwoCharacters(int[] units){
        playerTwoCharacters = new CharacterControllerAlien[units.Length];
        for (int i = 0; i < units.Length; i++){
            playerTwoCharacters[i].createCharacter(units[i]);
        }
    }

    static int playerOneCounter = 0;
    static int playerTwoCounter = 0;

    public static int getNextCharacterIndex(int player){
        int index;
        if (player == 1){
            index = playerOneCounter++;
            return index;
        }
        else{
            index = playerTwoCounter++;
            return index;
        }
    }

}