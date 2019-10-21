using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        startGame(0);
    }

    public static void startGame(int level){
        int seed = LevelData.LevelDefinitions[level].seed;
        TerrainHandler.generateMap(seed);

        int flag1 = LevelData.LevelDefinitions[level].flagTile1;
        int flag2 = LevelData.LevelDefinitions[level].flagTile2;

        PlayerVariables.flagTile1 = flag1;
        PlayerVariables.flagTile2 = flag2;
    }

    // Update is called once per frame
    void Update(){
        
    }
}
