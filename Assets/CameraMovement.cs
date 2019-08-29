using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float smoothTime = 0.05f;

    public int startX;
    public int startY;
    public int startZ;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(startX,startY,startZ);        //initialize camera start position
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
     {
         transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
     }
     if(Input.GetKey(KeyCode.LeftArrow))
     {
         transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
     }
     if(Input.GetKey(KeyCode.DownArrow))
     {
         transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
     }
     if(Input.GetKey(KeyCode.UpArrow))
     {
         transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
     }
    }
}
