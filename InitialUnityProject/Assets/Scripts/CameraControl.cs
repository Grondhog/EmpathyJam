using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    Camera Cam;
    public Transform target;

    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
        Cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 goalPos = target.position;
        goalPos.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
    }
}
