using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text HUD_AP;
    public Text HUD_SU;
    public Text HUD_SUI;
    public Text CURR_TURN;
    public Button END_TURN;

    void Start(){
        Button btn = END_TURN.GetComponent<Button>();
        btn.onClick.AddListener(PlayerVariables.nextTurn);
    }

    void Update(){
        // update text of Text element
        HUD_AP.text = "Turn AP: "+PlayerVariables.currentAP+"/"+PlayerVariables.maxAP;
        if (PlayerVariables.unitSelected != null) HUD_SU.text = "Selected Unit: " + PlayerVariables.unitSelected.unitName;
        else HUD_SU.text = "Selected Unit: None";
        HUD_SUI.text = "Selected Unit Info Here";

        CURR_TURN.text = "Current PLayer: "+(PlayerVariables.currentPlayer+1);
    }

    void end_turn_clicked(){
        PlayerVariables.nextTurn();
        Debug.Log("clicked");
    }
}
