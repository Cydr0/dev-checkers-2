using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerGeneric : MonoBehaviour {

    private bool selected = false;
    private bool grid = false;
    private GameObject gameController;
    private GameObject selectedTile;
    private Vector3 offset = new Vector3(0, 0.5f, 0);

    private void Start() {
        gameController = GameObject.Find("GameController");
    }

    void Update() {
        if (selectionCheck()) {
            movementCheck();
        }
    }

    bool selectionCheck() {
        // Check if unit is hit and select it if not already selected, or deselect if clicked elsewhere
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit && !selected) {
                selected = true;
            }
            else if (!hit && selected) {
                selected = false;
            }
        }

        if (selected && !grid) {
            gameController.GetComponent<GridDraw>().drawGrid();
            grid = true;
        }
        else if (!selected && grid) {
            gameController.GetComponent<GridDraw>().destroyGrid();
            grid = false;
        }

        return selected;
    }

    void movementCheck() {
        if (Input.GetMouseButtonDown(1) && selected == true) {
            selected = false;
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo)) {
                selectedTile = hitInfo.transform.gameObject;
            }
            this.transform.position = selectedTile.transform.position + offset;
        }
    }
}
