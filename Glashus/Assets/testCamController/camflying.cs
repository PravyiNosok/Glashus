﻿using UnityEngine;
using System.Collections;

public class camflying : MonoBehaviour {
    private Transform cam;
    [SerializeField]
    float speed = 5;
    [SerializeField]
    float MouseSensitive = 10;
    public Vector3 rot;
    private Vector3 tor;
	// Use this for initialization
	void Start () {
        cam = transform;
        tor = rot = cam.eulerAngles;
        rot.z = 0;
        cam.rotation = Quaternion.Euler(rot);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dirction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed;
        if (dirction != Vector3.zero)
            cam.Translate(dirction*Time.deltaTime);

        dirction = new Vector3(-Input.GetAxis("Mouse Y"),Input.GetAxis("Mouse X"), 0)*MouseSensitive;
            rot += dirction;
            rot.x = Mathf.Clamp(rot.x, -30, 45);
            tor = Vector3.Lerp(tor, rot, 10 * Time.deltaTime);
            cam.eulerAngles = tor;
	}
}
