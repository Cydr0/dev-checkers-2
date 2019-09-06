using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    public Vector2 position;
    public Material material;

    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void setType(Material mat)
    {
        material = mat;
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        Material[] mats = rend.materials;
        mats[0] = material;
        rend.materials = mats;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
