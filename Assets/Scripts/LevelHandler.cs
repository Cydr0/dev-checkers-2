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
        
    }
}
