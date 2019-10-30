using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerAlien : MonoBehaviour {

    // Character combat and class related variables
    // _class holds this charactercontroller's unit type, which controls model used
    // and will control which additional script is attached to this unit to give 
    // it class abilities
    int _class, _cost, _health, _range, _damage, _moveCost, _attackCost;
    public int _index;
    public GameObject digger; // _class = 1
    public GameObject scavenger; // _class = 2
    public GameObject hive; // _class = 3
    public GameObject eye; // _class = 4

    public void createCharacter(int c) {
        this._class = c;
        this._index = PlayerVariables.getNextCharacterIndex(2);
        switch(c) {
            case 1:
                digger.SetActive(true);
                this._cost = 2;
                this._health = 5;
                this._range = 2;
                this._damage = 3;
                this._moveCost = 2;
                this._attackCost = 4;
                break;
            case 2:
                scavenger.SetActive(true);
                this._cost = 1;
                this._health = 4;
                this._range = 1;
                this._damage = 2;
                this._moveCost = 1;
                this._attackCost = 2;
                break;
            case 3:
                hive.SetActive(true);
                this._cost = 3;
                this._health = 5;
                this._range = 2;
                this._damage = 2;
                this._moveCost = 4;
                this._attackCost = 2;
                break;
            case 4:
                eye.SetActive(true);
                this._cost = 3;
                this._health = 2;
                this._range = 3;
                this._damage = 3;
                this._moveCost = 4;
                this._attackCost = 3;
                break;
        }
        PlayerVariables.playerTwoCharacters[this._index] = this;
        return;
    }
}
