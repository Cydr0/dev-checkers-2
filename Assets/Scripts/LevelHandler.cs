using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        TerrainHandler.generateMap(12345);
    }

    public static void startGame(int level){
        int seed = LevelData.LevelDefinitions[level].seed;
        TerrainHandler.generateMap(seed);


    }

    // Update is called once per frame
    void Update(){
        
    }
}
