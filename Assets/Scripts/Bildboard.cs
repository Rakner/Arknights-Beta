using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bildboard : MonoBehaviour
{
    public Transform cam;
    public Camera camera;
    public Canvas thiscanvas;

    void Start()
    {
        camera = GameObject.Find("Camera").GetComponent<Camera>();
        cam = GameObject.Find("Camera").GetComponent<Transform>();
        
        thiscanvas.worldCamera = camera;
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
