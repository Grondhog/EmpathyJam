using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float SPEED = 3.0f;

	// Use this for initialization
	void Start () {
       Debug.Log("Walking with some tunes in.");
    }

    // Update is called once per frame
    void Update () {

        //Print every key pressed
        if (Input.anyKeyDown)
        {
            Debug.Log("Key pressed is: " + Input.inputString);
        }

        //Move character on a plane
        transform.Translate(SPEED * Time.deltaTime * Input.GetAxis("Horizontal"),0.0f, SPEED * Time.deltaTime * Input.GetAxis("Vertical"));
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with." + other.GetComponent<Collider>().name);
    }
}
