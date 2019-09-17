using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    public Vector2 position;
    public Material material;
    public int index;

    int movementCost = 1;

    Renderer rend;

    TerrainData.TerrainType type;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public TerrainData.TerrainType getType(){
        return type;
    }

    public void setType(TerrainData.TerrainType _type)
    {
        type = _type;

        material = type.material;
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        Material[] mats = rend.materials;
        mats[0] = material;
        rend.materials = mats;

        movementCost = type.movementCost;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
