using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text HUD_AP;
    public Text HUD_SU;
    public Text HUD_SUI;

    void Start(){
    }

    void Update(){
        // update text of Text element
        HUD_AP.text = "Turn AP: "+PlayerVariables.currentAP+"/"+PlayerVariables.maxAP;
        HUD_SU.text = "Selected Unit: none";
        HUD_SUI.text = "Selected Unit Info Here";
    }
}
