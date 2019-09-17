using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerGeneric : MonoBehaviour {

    public bool selected = false;
    private bool grid = false;

    private GameObject gameController;
    private GameObject selectedTile;
    private GameObject lastSelected;
    public GameObject currentTile;

    TerrainHandler terrainHandler;

    public Vector3 offset = new Vector3(0, 0.5f, 0);

    Material currentMaterial;

    private void Awake() {
        lastSelected = new GameObject();
    }

    private void Start() {
        gameController = GameObject.Find("GameController");
        terrainHandler = gameController.GetComponent<TerrainHandler>();
        currentMaterial = GetComponent<Renderer>().material;
        currentTile = gameController.GetComponent<TerrainHandler>().cells[0].transform.gameObject;
        this.transform.position = currentTile.transform.position + offset;
    }

    void Update() {
        if (selectionCheck()) {
            movementCheck();
        }
        materialCheck();
    }

    void materialCheck() {
        if (selected) this.currentMaterial.color = Color.red;
        else this.currentMaterial.color = Color.gray;
    }

    bool selectionCheck() {
        // Check if unit is hit and select it if not already selected, or deselect if clicked elsewhere
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (!hit) {
                selected = false;
                PlayerVariables.unitSelected = null;
                Debug.Log(selected);
                return false;
            }
            if (lastSelected != hitInfo.transform.gameObject && selected) {
                selected = false;
                PlayerVariables.unitSelected = null;
                Debug.Log(selected);
                return false;
            }
            selected = true;
            lastSelected = hitInfo.transform.gameObject;
            PlayerVariables.unitSelected = this;
            Debug.Log(selected);
            Debug.Log(lastSelected);
        }
        return selected;
    }

    void movementCheck() {
        if (Input.GetMouseButtonDown(1) && selected == true) {
            selected = false;
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            selectedTile = hitInfo.transform.gameObject;
            Debug.Log("Raycast hit " + selectedTile);
            if (hit && hitInfo.transform.gameObject.tag == "Tile") {
                int cellIndex = currentTile.GetComponent<HexCell>().index;
                int selectedTileIndex = selectedTile.GetComponent<HexCell>().index;
                int[] neighbours = terrainHandler.getNeighbours(cellIndex);
                bool found = false;
                for (int i = 0; i != neighbours.Length && found != true; i++) {
                    if (neighbours[i] >= 0) {
                        int neighbourIndex = neighbours[i];
                        if (neighbourIndex == selectedTileIndex) {
                            found = true;
                            break;
                        }
                    }
                }
                if (this.gameObject != selectedTile && found == true) {
                    this.transform.position = selectedTile.transform.position + offset;
                    currentTile = selectedTile;
                }
            }
        }
    }
}
