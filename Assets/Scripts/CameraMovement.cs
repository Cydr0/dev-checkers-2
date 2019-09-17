using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public static int smoothTime = 20;

    public string decayType = "exp";    // Can be exp, or log

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
        if(decayType == "exp"){     // f(x) = e^(log(speed)/(smooth time var))
            if(Input.GetKey(KeyCode.D)){    // Right
                GetComponent<Camera>().transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
                rightBool = true;
                leftBool = false;
            }else if(rightBool && rightSmoothTime-1 > 0){
                GetComponent<Camera>().transform.Translate(new Vector3(-Mathf.Exp(Mathf.Log(speed)/(smoothTime - (rightSmoothTime-1))) * Time.deltaTime,0,0));
                rightSmoothTime--;
            }else{
                rightSmoothTime = smoothTime;
                rightBool = false;
            }

            if(Input.GetKey(KeyCode.A)){    // Left
                GetComponent<Camera>().transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
                leftBool = true;
                rightBool = false;
            }else if(leftBool && leftSmoothTime-1 > 0){
                GetComponent<Camera>().transform.Translate(new Vector3(Mathf.Exp(Mathf.Log(speed)/(smoothTime - (leftSmoothTime-1))) * Time.deltaTime,0,0));
                leftSmoothTime--;
            }else{
                leftSmoothTime = smoothTime;
                leftBool= false;
            }

            if(Input.GetKey(KeyCode.S)){    // Down
                GetComponent<Camera>().transform.Translate(new Vector3(0,(speed * Time.deltaTime),0));
                downBool = true;
                upBool = false;
            }else if(downBool && downSmoothTime-1 > 0){
                GetComponent<Camera>().transform.Translate(new Vector3(0,(Mathf.Exp(Mathf.Log(speed)/(smoothTime - (downSmoothTime-1))) * Time.deltaTime),0));
                downSmoothTime--;
            }else{
                downSmoothTime = smoothTime;
                downBool = false;
            }

            if(Input.GetKey(KeyCode.W)){    // Up
                GetComponent<Camera>().transform.Translate(new Vector3(0,(-speed * Time.deltaTime),0));
                upBool = true;
                downBool = false;
            }else if(upBool && upSmoothTime-1 > 0){
                GetComponent<Camera>().transform.Translate(new Vector3(0,(-Mathf.Exp(Mathf.Log(speed)/(smoothTime - (upSmoothTime-1))) * Time.deltaTime),0));
                upSmoothTime--;
            }else{
                upSmoothTime = smoothTime;
                upBool = false;
            }
        }/*else if(decayType == "log"){   // f(x) = speed - (-3.57092*10^(-6)(smoothTime)^(3)+0.000845061(smoothTime)^(2)-0.0715902(smoothTime)+4.44856)log(x)
            if(Input.GetKey(KeyCode.D)){    // Right
                GetComponent<Camera>().transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
                rightBool = true;
                leftBool = false;
            }else if(rightBool && rightSmoothTime-1 > 0){
                GetComponent<Camera>().transform.Translate(new Vector3(-(speed - (Mathf.Pow(-3.57092*10,-6)Mathf.Pow(smoothTime,3)+Mathf.Pow(0.000845061(smoothTime),2)-0.0715902(smoothTime)+4.44856)Mathf.Log(smoothTime - (rightSmoothTime-1))) * Time.deltaTime,0,0));
                rightSmoothTime--;
            }else{
                rightSmoothTime = smoothTime;
                rightBool = false;
            }

            if(Input.GetKey(KeyCode.A)){    // Left
                GetComponent<Camera>().transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
                leftBool = true;
                rightBool = false;
            }else if(leftBool && leftSmoothTime-1 > 0){
                GetComponent<Camera>().transform.Translate(new Vector3(Mathf.Log(smoothTime - (leftSmoothTime-1))+speed * Time.deltaTime,0,0));
                leftSmoothTime--;
            }else{
                leftSmoothTime = smoothTime;
                leftBool= false;
            }

            if(Input.GetKey(KeyCode.S)){    // Down
                GetComponent<Camera>().transform.Translate(new Vector3(0,(speed * Time.deltaTime),0));
                downBool = true;
                upBool = false;
            }else if(downBool && downSmoothTime-1 > 0){
                GetComponent<Camera>().transform.Translate(new Vector3(0,(Mathf.Log(smoothTime - (downSmoothTime-1))+speed * Time.deltaTime),0));
                downSmoothTime--;
            }else{
                downSmoothTime = smoothTime;
                downBool = false;
            }

            if(Input.GetKey(KeyCode.W)){    // Up
                GetComponent<Camera>().transform.Translate(new Vector3(0,(-speed * Time.deltaTime),0));
                upBool = true;
                downBool = false;
            }else if(upBool && upSmoothTime-1 > 0){
                GetComponent<Camera>().transform.Translate(new Vector3(0,(-Mathf.Log(smoothTime - (upSmoothTime-1))+speed * Time.deltaTime),0));
                upSmoothTime--;
            }else{
                upSmoothTime = smoothTime;
                upBool = false;
            }
        }*/
    }
}
