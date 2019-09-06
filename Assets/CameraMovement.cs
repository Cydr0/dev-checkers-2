using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public static int smoothTime = 10;

    public int startX;
    public int startY;
    public int startZ;

    private int rightTime = 0;
    private int leftTime = 0;
    private int downTime = 0;
    private int upTime = 0;

    private int rightSmoothTime = smoothTime;
    private int leftSmoothTime = smoothTime;
    private int downSmoothTime = smoothTime;
    private int upSmoothTime = smoothTime;


    // Start is called before the first frame update
    void Start(){
        transform.position = new Vector3(startX,startY,startZ);        //initialize camera start position
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
            rightTime++;
        }else if(rightTime > 0 && rightSmoothTime > 0){
            transform.Translate(new Vector3((speed/(smoothTime - rightSmoothTime)) * Time.deltaTime,0,0));
            rightSmoothTime--;
        }else if(rightSmoothTime == 0){
            rightSmoothTime = smoothTime;
            rightTime = 0;
        }

        if(Input.GetKey(KeyCode.A)){
            transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
            leftTime++;
        }else if(leftTime > 0 && leftSmoothTime > 0){
            transform.Translate(new Vector3((-speed/(smoothTime - leftSmoothTime)) * Time.deltaTime,0,0));
            leftSmoothTime--;
        }else if(leftSmoothTime == 0){
            leftSmoothTime = smoothTime;
            leftTime = 0;
        }

        if(Input.GetKey(KeyCode.S)){
            transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
            downTime++;
        }else if(downTime > 0 && downSmoothTime > 0){
            transform.Translate(new Vector3(0,(-speed/(smoothTime - downSmoothTime)) * Time.deltaTime,0));
            downSmoothTime--;
        }else if(downSmoothTime == 0){
            downSmoothTime = smoothTime;
            downTime = 0;
        }

        if(Input.GetKey(KeyCode.W)){
            transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
            upTime++;
        }else if(upTime > 0 && upSmoothTime > 0){
            transform.Translate(new Vector3(0,(speed/(smoothTime - upSmoothTime)) * Time.deltaTime,0));
            upSmoothTime--;
        }else if(upSmoothTime == 0){
            upSmoothTime = smoothTime;
            upTime = 0;
        }
    }
}
