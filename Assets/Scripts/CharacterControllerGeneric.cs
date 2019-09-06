using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerGeneric : MonoBehaviour {

    private bool selected = false;
    private bool grid = false;
    private GameObject gameController;

    private void Start() {
        gameController = GameObject.Find("GameController");
    }

    void Update() {
        selectionLoop();
    }

    void selectionLoop() {
        // Check if unit is hit and select it if not already selected, or deselect if clicked elsewhere
        if (Input.GetMouseButtonDown(0)) {        
            RaycastHit hitInfo = new RaycastHit();
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
    }
}
