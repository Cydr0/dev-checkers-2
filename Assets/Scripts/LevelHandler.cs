using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{

    public flag flagPrefab;
    public static flag staticFlagPrefab;

    public static flag flagP1;
    public static flag flagP2;

    // Start is called before the first frame update
    void Start(){
        staticFlagPrefab = flagPrefab;

        startGame(0);
    }

    public static void startGame(int level){
        int seed = LevelData.LevelDefinitions[level].seed;
        TerrainHandler.generateMap(seed);

        int flag1 = LevelData.LevelDefinitions[level].flagTile1;
        int flag2 = LevelData.LevelDefinitions[level].flagTile2;

        PlayerVariables.flagTile1 = flag1;
        PlayerVariables.flagTile2 = flag2;

        int goal1 = LevelData.LevelDefinitions[level].goalTile1;
        int goal2 = LevelData.LevelDefinitions[level].goalTile2;

        PlayerVariables.flagTile1 = flag1;
        PlayerVariables.flagTile2 = flag2;

        PlayerVariables.setPlayerOneCharacters(LevelData.LevelDefinitions[level].units1);
        PlayerVariables.setPlayerTwoCharacters(LevelData.LevelDefinitions[level].units2);

        //InitialiseGoals


        flagP1 = Instantiate(staticFlagPrefab);
        Vector3 pos = TerrainHandler.cells[flag1].transform.position;
        pos.y += 0.3f;
        flagP1.transform.position = pos;
        flagP1.name = "Player 1 Flag";


        flagP2 = Instantiate(staticFlagPrefab);
        pos = TerrainHandler.cells[flag2].transform.position;
        pos.y += 0.3f;
        flagP2.transform.position = pos;
        flagP2.name = "Player 2 Flag";
    }

    // Update is called once per frame
    void Update(){
        if (PlayerVariables.showFlag1){
            Renderer rend = flagP1.GetComponent<Renderer>();
            rend.enabled = true;
        }
        else{
            Renderer rend = flagP1.GetComponent<Renderer>();
            rend.enabled = false;
        }

        if (PlayerVariables.showFlag2){
            Renderer rend = flagP2.GetComponent<Renderer>();
            rend.enabled = true;
        }
        else{
            Renderer rend = flagP2.GetComponent<Renderer>();
            rend.enabled = false;
        }
    }
}
