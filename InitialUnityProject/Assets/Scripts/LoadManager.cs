using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour {

    public static GameObject player;

    private static int timeOfDay = 1;//Gross 0 == day 1 == night
    public static int currentDay = 0;//0 == FRIDAY 4 == MONDAY
    private static int maxDay = 4;

    public static void LoadNextDay()
    {
        timeOfDay = 0;
        currentDay++;
        Debug.Log("Current Day: " + currentDay);
    }

    

	public static void LoadToFrom(string toScene, string fromScene)
    {
        
        Vector3 pos = new Vector3(0,0,0);
        if (fromScene == "DinnerScene")
        {
            pos = new Vector3(9, 1, -24);
        }
        else if (toScene == "SchoolScene")
        {
            if (fromScene == "ParkScene")
            {
                pos = new Vector3(33, 1, -10);
            }
            else if (fromScene == "ResidentialScene")
            {
                pos = new Vector3(0, 1, -35);
            }
        }
        else if (toScene == "ParkScene")
        {
            if (fromScene == "CommercialScene")
            {
                pos = new Vector3(-20, 1, -45);
            }
            else if (fromScene == "SchoolScene")
            {
                pos = new Vector3(-36, 1, 0);
            }
        }
        else if (toScene == "CommercialScene")
        {
            if (fromScene == "ResidentialScene")
            {
                pos = new Vector3(-32, 1, 0);
            }
            else if (fromScene == "ParkScene")
            {
                pos = new Vector3(-0, 1, 32);
            }
        }
        else if (toScene == "ResidentialScene")
        {
            if (fromScene == "CommercialScene")
            {
                pos = new Vector3(32, 1, 0);
            }
            else if(fromScene == "SchoolScene")
            {
                pos = new Vector3(0, 1, 32);
            }
        }
        Application.LoadLevel(toScene);
        //GameObject temp = Instantiate(Resources.Load("PlayerCharacter"), pos, Quaternion.identity) as GameObject;//GameObject.Find("PlayerCharacter");//Instantiate(player, pos, Quaternion.identity);
        //GameObject.Find("PlayerCharacter").transform.position = pos;
        //GameObject.F
        //Debug.Log(GameObject.Find("PlayerCharacter").transform.position);
        //Debug.Log(temp);
        //temp.transform.position = pos;
        
        //CameraControl camCon = Camera.main.GetComponent<CameraControl>();
        //camCon.target = temp.transform;
        //Debug.Log(camCon.target);

    }
}
