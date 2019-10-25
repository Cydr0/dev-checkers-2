using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainData : MonoBehaviour
{
    public struct TerrainType
    {
        public Material material;
        public int movementCost;
        public string name;
        public float heightThreshold;

        public TerrainType(Material _mat, int _moveC, string _name, float height){
            material = _mat;
            movementCost = _moveC;
            name = _name;
            heightThreshold = height;
        }
    }

    public Material t1;
    public Material t2;
    public Material t3;

    public static TerrainType[] terrainTypes;

    bool isNull(TerrainType type){
        return type.name.Equals("null");
    }

    // Start is called before the first frame update
    void Awake()
    {
        terrainTypes = new TerrainType[3];

        terrainTypes[0] = new TerrainType(t1, 1, "ground0", 2);
        terrainTypes[1] = new TerrainType(t2, 2, "ground1", 1);
        terrainTypes[2] = new TerrainType(t3, -1, "obstacle", 1);

        float total = 0;
        for (int i = 0; i < terrainTypes.Length; i++)
        {
            total += terrainTypes[i].heightThreshold;
        }
        total *= 1.2f;
        for (int i = 0; i < terrainTypes.Length; i++)
        {
            terrainTypes[i].heightThreshold /= total;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
