
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
﻿using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent))]


public class CharacterMovement : MonoBehaviour
{

    //Movement Speed of the character
    public float SPEED = 50.0f;


    //Directon the player is facing
    Vector3 DIR;

    void Start()
    {
        //Debug.Log("Walking with some tunes in.");
        // Use this for initialization
    }

    // Update is called once per frame
    void Update()
    {

        //Keep the player always facing the  direction they are walking
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * SPEED;
            //print("UP");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * SPEED;
            //print("LEFT");
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * SPEED;
            //print("DOWN");
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * SPEED;
            //print("RIGHT");
        }
        else
        {
            transform.position = transform.position;
        }


    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("Collision detected with." + other.GetComponent<Collider>().name);

        if (Input.GetKeyDown("space"))
        {
            //print("Hullo there, I am trying to speak.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        if (other.tag == "ToSchool")
        {
            LoadManager.LoadToFrom("SchoolScene", SceneManager.GetActiveScene().name);
            //Application.LoadLevel("SchoolScene");
        }
        else if (other.tag == "ToPark")
        {
            LoadManager.LoadToFrom("ParkScene", SceneManager.GetActiveScene().name);
            //Application.LoadLevel("ParkScene");
        }
        else if (other.tag == "ToResidential")
        {
            LoadManager.LoadToFrom("ResidentialScene", SceneManager.GetActiveScene().name);
            //Application.LoadLevel("ResidentialScene");
        }
        else if (other.tag == "ToComercial")
        {
            LoadManager.LoadToFrom("CommercialScene", SceneManager.GetActiveScene().name);
            //Application.LoadLevel("CommercialScene");
        }
    }
}
