using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public struct LevelDefinition
    {
        public int seed;
        public int flagTile1;
        public int flagTile2;

        public LevelDefinition(int _seed, int _flag1, int _flag2){
            seed = _seed;
            flagTile1 = _flag1;
            flagTile2 = _flag2;
        }
    }
    public static LevelDefinition[] LevelDefinitions;

    // Start is called before the first frame update
    void Awake()
    {
        LevelDefinitions = new LevelDefinition[5];

        LevelDefinitions[0] = new LevelDefinition(12345, 0, 11);
        LevelDefinitions[1] = new LevelDefinition(12346, 0, 11);
        LevelDefinitions[2] = new LevelDefinition(12347, 0, 11);
        LevelDefinitions[3] = new LevelDefinition(12348, 0, 11);
        LevelDefinitions[4] = new LevelDefinition(12349, 0, 11);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
