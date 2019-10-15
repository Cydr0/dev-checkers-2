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

    public void playButton(){
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }

    public void startGame(int level){
        SceneManager.LoadScene("DemoScene", LoadSceneMode.Single);
        LevelHandler.startGame(level);
    }

    public void levelSelect(){
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }

    public void quitButton(){
        Application.Quit();
    }
}
