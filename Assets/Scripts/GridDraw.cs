using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class GridDraw : MonoBehaviour{
    public int gridSize = 5;
    public Material gridMaterial;
    GameObject terrainHandler;

    float hexWidth;
    float hexHeight;

    private void Start() {
        terrainHandler = GameObject.Find("TerrainHandler");
        hexWidth = terrainHandler.GetComponent<TerrainHandler>().hexWidth;
        hexHeight = terrainHandler.GetComponent<TerrainHandler>().hexHeight;
    }

    public void drawGrid() {
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        var mesh = new Mesh();
        var verticies = new List<Vector3>();
        var indicies = new List<int>();

        for (int i = 0; i < gridSize; i++) {
            verticies.Add(new Vector3(i, 0, 0));
            verticies.Add(new Vector3(i, 0, gridSize));

            indicies.Add(4 * i + 0);
            indicies.Add(4 * i + 1);

            verticies.Add(new Vector3(0, 0, i));
            verticies.Add(new Vector3(gridSize, 0, i));

            indicies.Add(4 * i + 2);
            indicies.Add(4 * i + 3);
        }

        mesh.vertices = verticies.ToArray();
        mesh.SetIndices(indicies.ToArray(), MeshTopology.Lines, 0);
        filter.mesh = mesh;

        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material = gridMaterial;
    }

    public void destroyGrid() {
        Destroy(this.GetComponent<MeshFilter>());
    }
}
