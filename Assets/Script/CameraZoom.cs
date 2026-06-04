using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera camera;
    private float zoomTarget;
    [SerializeField] private float multiplier = 2f;
    [SerializeField] private float minZoom = 1f;
    [SerializeField] private float maxZoom = 10f;
    [SerializeField] private float smoothTime = 0.1f;
    [SerializeField] private float velocity = 0f;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();        
        zoomTarget = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        //camera.orthographicSize -= Input.GetAxisRaw("Mouse ScrollWheel") * multiplier;
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)    
        {
            zoomTarget -= Input.GetAxisRaw("Mouse ScrollWheel") * multiplier;
            zoomTarget = Mathf.Clamp(zoomTarget, minZoom, maxZoom);
            camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, zoomTarget, ref velocity, smoothTime);
        }
    }
}
