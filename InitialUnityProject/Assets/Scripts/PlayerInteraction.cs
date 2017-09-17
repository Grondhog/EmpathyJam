using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public TextBoxManager tbMan;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckInput();
        //tbMan.bActive = false;
	}

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            tbMan.EnableTextBox();
            tbMan.LoadTextData(new TextAsset()       LoadTextData(TextAsset taNewFile, int iNewStartingLine, int iNewEndingLine)
            LoadManager.LoadNextDay();

            //tbMan.bActive = true;
        }
    }
}
