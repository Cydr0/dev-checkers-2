using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public static int smoothTime = 75;

    public int startX;
    public int startY;
    public int startZ;

    private bool rightBool = false;
    private bool leftBool = false;
    private bool downBool = false;
    private bool upBool = false;

    private int rightSmoothTime = smoothTime;
    private int leftSmoothTime = smoothTime;
    private int downSmoothTime = smoothTime;
    private int upSmoothTime = smoothTime;


    // Start is called before the first frame update
    void Start(){
        //transform.positon(new Vector3(startX, startY, startZ));
        //GetComponent<Camera>().transform.position = new Vector3(startX,startY,startZ);        //initialize camera start position
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKey(KeyCode.D)){    // Right
            GetComponent<Camera>().transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
            rightBool = true;
        }else if(rightBool && rightSmoothTime-1 > 0){
            GetComponent<Camera>().transform.Translate(new Vector3((-speed/(smoothTime - (rightSmoothTime-1))) * Time.deltaTime,0,0));
            rightSmoothTime--;
        }else{
            rightSmoothTime = smoothTime;
            rightBool = false;
        }

        if(Input.GetKey(KeyCode.A)){    // Left
            GetComponent<Camera>().transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
            leftBool = true;
        }else if(leftBool && leftSmoothTime-1 > 0){
            GetComponent<Camera>().transform.Translate(new Vector3((speed/(smoothTime - (leftSmoothTime-1))) * Time.deltaTime,0,0));
            leftSmoothTime--;
        }else{
            leftSmoothTime = smoothTime;
            leftBool= false;
        }

        if(Input.GetKey(KeyCode.S)){    // Down
            GetComponent<Camera>().transform.Translate(new Vector3(0,(-speed * Time.deltaTime),0));
            downBool = true;
        }else if(downBool && downSmoothTime-1 > 0){
            GetComponent<Camera>().transform.Translate(new Vector3(0,((-speed/(smoothTime - (downSmoothTime-1))) * Time.deltaTime),0));
            downSmoothTime--;
        }else{
            downSmoothTime = smoothTime;
            downBool = false;
        }

        if(Input.GetKey(KeyCode.W)){    // Up
            GetComponent<Camera>().transform.Translate(new Vector3(0,(speed * Time.deltaTime),0));
            upBool = true;
        }else if(upBool && upSmoothTime-1 > 0){
            GetComponent<Camera>().transform.Translate(new Vector3(0,((speed/(smoothTime - (upSmoothTime-1))) * Time.deltaTime),0));
            upSmoothTime--;
        }else{
            upSmoothTime = smoothTime;
            upBool = false;
        }
    }
}
