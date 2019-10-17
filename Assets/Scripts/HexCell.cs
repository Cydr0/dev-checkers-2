using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour {
    public Vector2 position;
    public Material material;
    public int index;

    // Wether the tile has an object
    public bool hasObject;
    // The type of object, where 0 is safe, 1 is friendly, 2 is enemy, 3 is flag
    public int objectType;
    // Enemy on the tile
    public CharacterControllerGeneric enemyOnTile;

    int movementCost = 1;

    Renderer rend;

    TerrainData.TerrainType type;

    // Start is called before the first frame update
    void Start() {


    }

    public TerrainData.TerrainType getType() {
        return type;
    }

    public void setType(TerrainData.TerrainType _type) {
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
    void Update() {

    }
}
