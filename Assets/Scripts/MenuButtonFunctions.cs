using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void playButton()
    {
        SceneManager.LoadScene("TerrainTest", LoadSceneMode.Additive);
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
