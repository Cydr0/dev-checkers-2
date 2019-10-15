using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public struct LevelDefinition
    {
        public int seed;

        public LevelDefinition(int _seed)
        {
            seed = _seed;
        }
    }
    public static LevelDefinition[] LevelDefinitions;

    // Start is called before the first frame update
    void Awake()
    {
        LevelDefinitions = new LevelDefinition[5];

        LevelDefinitions[0] = new LevelDefinition(12345);
        LevelDefinitions[1] = new LevelDefinition(12346);
        LevelDefinitions[2] = new LevelDefinition(12347);
        LevelDefinitions[3] = new LevelDefinition(12348);
        LevelDefinitions[4] = new LevelDefinition(12349);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
