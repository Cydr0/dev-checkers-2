using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoom = 20f;
    public float zoomSpeed = 5f;
    Transform cam; 

    void Start(){
        cam = this.transform;
    }

    void Update(){
        zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        transform.position = new Vector3(cam.position.x, zoom, cam.position.z);
    }
}
