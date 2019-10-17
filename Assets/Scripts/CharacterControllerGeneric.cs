using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerGeneric : MonoBehaviour {

    public bool selected = false;
    bool isPlaced = false;
    bool hasEnemy = false;
    public int startingIndex = 0;
    public int playerIndex = 0;

    private GameObject gameController;
    private GameObject selectedTile;
    private GameObject lastSelected;
    private GameObject currentTile;
    private GameObject tileMoveAttempt;

    // Combat Stats
    public int attack;
    public int defense;
    public int hp;

    TerrainHandler terrainHandler;

    public Vector3 offset = new Vector3(0, 0.5f, 0);

    public string unitName = "AlienGrunt";

    Material currentMaterial;

    private void Awake() {
        lastSelected = new GameObject();
    }

    private void Start() {
        gameController = GameObject.Find("GameController");
        terrainHandler = gameController.GetComponent<TerrainHandler>();
        currentMaterial = GetComponent<Renderer>().material;

        // Initialize combat stats
        CharacterClass characterClass = GetComponent<CharacterClass>();
    }

    void Update() {
        if (!isPlaced) {
            currentTile = TerrainHandler.cells[startingIndex].transform.gameObject;
            this.transform.position = currentTile.transform.position + offset;
            isPlaced = true;
        }
        if (playerIndex == PlayerVariables.currentPlayer) {
            if (SelectionCheck()) {
                if (MovementCheck()) {
                    if (!ObjectCheck()) {
                        movePlayer();
                    } else {
                        movePlayer();
                    }
                }
            }
            MaterialCheck();
        }
    }

    void MaterialCheck() {
        if (selected) this.currentMaterial.color = Color.red;
        else this.currentMaterial.color = Color.gray;
    }

    bool SelectionCheck() {
        // Check if unit is hit and select it if not already selected, or deselect if clicked elsewhere
        if (Input.GetMouseButtonDown(0)) {
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo);
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
        }
        return selected;
    }

    bool MovementCheck() {
        if (Input.GetMouseButtonDown(1) && selected == true) {
            selected = false;
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo);
            selectedTile = hitInfo.transform.gameObject;
            Debug.Log("Raycast hit " + selectedTile + ", tag " + selectedTile.tag);
            // check if tile was hit
            if (hit && hitInfo.transform.gameObject.tag == "Tile") {
                int cellIndex = currentTile.GetComponent<HexCell>().index;
                int selectedTileIndex = selectedTile.GetComponent<HexCell>().index;
                int[] neighbours = terrainHandler.getNeighbours(cellIndex);
                bool found = false;
                // check if tile is a valid neighbouring tile
                for (int i = 0; i != neighbours.Length && found != true; i++) {
                    if (neighbours[i] >= 0) {
                        int neighbourIndex = neighbours[i];
                        if (neighbourIndex == selectedTileIndex) {
                            found = true;
                            Debug.Log("Is a neighbour");
                            break;
                        }
                    }
                }
                // move onto tile if tile is accessable and the player has enough AP
                int currentTileMoveCost = terrainHandler.getTileType(selectedTileIndex).movementCost;
                if (this.gameObject != selectedTile && found == true &&
                    currentTileMoveCost != -1 && PlayerVariables.currentAP >= currentTileMoveCost) {
                    this.tileMoveAttempt = selectedTile;
                    return true;
                }
            }
        }
        return false;
    }

    bool ObjectCheck() {
        GameObject selectedTile = this.tileMoveAttempt;
        if (selectedTile.GetComponent<HexCell>().hasObject) {
            int objectType = selectedTile.GetComponent<HexCell>().objectType;
            if (objectType == 0) {
                Debug.Log("Hit a safe object, moving");
                return true;
            } if (objectType == 1) {
                Debug.Log("Hit a friendly, cancelling");
                return false;
            } if (objectType == 2) {
                Debug.Log("Hit an enemy, entering combat");
                CharacterControllerGeneric enemy = selectedTile.GetComponent<HexCell>().enemyOnTile;
                if (CombatCheck(enemy)) {
                    return true;
                }
            } if (objectType == 3) {
                Debug.Log("Hit a flag, picking up");
                getFlag();
                return true;
            }
        }
        return true;
    }

    bool CombatCheck(CharacterControllerGeneric enemy) {
        int enemyHp = enemy.hp;
        int enemyAttack = enemy.attack;
        int enemyDefense = enemy.defense;

        // Calculate damages
        int hpLost = enemyAttack - defense;
        int enemyHpLost = attack - enemyDefense;

        // Destroy enemy if it is defeated, else take off health
        if (enemyHp <= enemyHpLost) {
            destroyUnit(enemy);
        } else {
            enemyHp -= enemyHpLost;
        }

        // Destroy this unit if it is defeated, else take off health
        if (hp <= hpLost) {
            destroyUnit(this);
        } else {
            hp -= hpLost;
        }
        return true;
    }

    void getFlag() {

    }

    void destroyUnit(CharacterControllerGeneric unit) {

    }

    void movePlayer() {
        // Code block to move player to this.tileMoveAttempt
        this.transform.position = tileMoveAttempt.transform.position + offset;
        currentTile = tileMoveAttempt;
        PlayerVariables.currentAP -= terrainHandler.getTileType(tileMoveAttempt.GetComponent<HexCell>().index).movementCost;
        PlayerVariables.unitSelected = null;
    }
}