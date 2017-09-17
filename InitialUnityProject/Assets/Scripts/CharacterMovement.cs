using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class CharacterMovement : MonoBehaviour {

    public float SPEED = 3.0f;

	// Use this for initialization
	void Start () {
       //Debug.Log("Walking with some tunes in.");
    }

    // Update is called once per frame
    void Update () {

        //Print every key pressed
        if (Input.anyKeyDown)
        {
            //Debug.Log("Key pressed is: " + Input.inputString);
        }

        //Move character on a plane
        transform.Translate(SPEED * Time.deltaTime * Input.GetAxis("Horizontal"),0.0f, SPEED * Time.deltaTime * Input.GetAxis("Vertical"));
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
        if (other.tag == "ToSchool")
        {
            Application.LoadLevel("SchoolScene");
            
        }
        else if (other.tag == "ToPark")
        {
            Application.LoadLevel("ParkScene");
        }
        else if (other.tag == "ToResidential")
        {
            Application.LoadLevel("ResidentialScene");
        }
        else if (other.tag == "ToComercial")
        {
            Application.LoadLevel("CommercialScene");
        }
    }
}
