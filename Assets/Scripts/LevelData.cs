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
        public int goalTile1;
        public int goalTile2;
        public int[] units1;
        public int[] units2;

        public LevelDefinition(int _seed, int _flag1, int _flag2, int _goal1, int _goal2, int[] _units1, int[] _units2){
            seed = _seed;
            flagTile1 = _flag1;
            flagTile2 = _flag2;

            goalTile1 = _goal1;
            goalTile2 = _goal2;

            units1 = _units1;
            units2 = _units2;
    }
    }
    public static LevelDefinition[] LevelDefinitions;

    // Start is called before the first frame update
    void Awake()
    {
        LevelDefinitions = new LevelDefinition[5];

        LevelDefinitions[0] = new LevelDefinition(12345, 1, 59, 58, 2, new int[]{ 1, 1, 2, 4 }, new int[]{ 2, 3, 4, 1 });
        LevelDefinitions[1] = new LevelDefinition(12346, 0, 11, 0, 0, new int[] { 1 }, new int[] { 1 });
        LevelDefinitions[2] = new LevelDefinition(12347, 0, 11, 0, 0, new int[] { 1 }, new int[] { 1 });
        LevelDefinitions[3] = new LevelDefinition(12348, 0, 11, 0, 0, new int[] { 1 }, new int[] { 1 });
        LevelDefinitions[4] = new LevelDefinition(12349, 0, 11, 0, 0, new int[] { 1 }, new int[] { 1 });
    }
    // Update is called once per frame
    void Update()
    {

    }
}
