
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent))]


public class CharacterMovement : MonoBehaviour
{

    //Movement Speed of the character
    public float SPEED = 50.0f;

    public TextBoxManager schoolClosedManager;

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
            //transform.position += transform.forward * Time.deltaTime * SPEED;
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            transform.Translate(0, 0, SPEED * Time.deltaTime, Space.World);

            //print("UP");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-SPEED * Time.deltaTime, 0, 0, Space.World);
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            //transform.position -= transform.right * Time.deltaTime * SPEED;
            //print("LEFT");
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            //transform.position -= transform.forward * Time.deltaTime * SPEED;
            transform.Translate(0, 0, -SPEED * Time.deltaTime, Space.World);
            //print("DOWN");
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
            transform.Translate(SPEED * Time.deltaTime, 0, 0, Space.World);
            //transform.position += transform.right * Time.deltaTime * SPEED;
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
        else if(other.tag == "ToFinale")
        {
            if (LoadManager.currentDay >= 4)
            {
                LoadManager.LoadToFrom("FinaleScene", SceneManager.GetActiveScene().name);
            }
            else
            {
                schoolClosedManager.EnableTextBox();
                StartCoroutine(RemoveTextBoxAfterXSeconds(3));
            }
        }
    }

    IEnumerator RemoveTextBoxAfterXSeconds(int x)
    {
        yield return new WaitForSeconds(x);
        schoolClosedManager.DisableTextBox();
    }
}
