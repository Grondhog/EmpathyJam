using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{

    public bool bActive; //Bool to keep track of if the text box is currently in use or not. 

    public GameObject goTextBox; //Text box behind the text itself.
    public Text tText; //Text object we display our text lines to.

    public TextAsset taFile; //Text file we start out with. Parsed into the string array during start, then is no longer used. 

    public string[] sTextLines; //List of strings to display in our text box. This probably shouldn't be public, but seeing which strings we have loaded is helpful for debugging.

    public int iStartingLine; // Which text line we start at in our text file. Is validated before usage. 
    public int iCurrentLine; // Which text line the player is currently on. 
    public int iEndingLine; // Which text line we end at in our text file. Is validated before usage. 

    //OPTIONAL variable, leave blank if you don't specifically need to use this.
    //If set, will attempt to load the level with this name when the last line of dialog is dismissed by the player.
    public string sNewLevel = ""; 

    // Use this for initialization
    void Start()
    {

        //Run validation on our starting files, just to make sure everything works. 
        LoadTextData(taFile, iStartingLine, iEndingLine);


        //Enable or disable the text box, based upon the starting value of our activation bool.
        if (bActive == true)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (bActive == true)
        {
            //If we've reached the end of our text lines, disable the text box. 
            if (iCurrentLine > iEndingLine)
            {
                DisableTextBox();
                return; //Abort the update function for this frame if we just disabled the text box. 
            }

            //If the text box is still active, update the displayed text lines.
            //Because our array is 0-indexed but the lines are 1-indexed, we also need to lower the line count by 1.
            tText.text = sTextLines[iCurrentLine - 1];

            //Check input to see if we need to advance to the next text line.
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                iCurrentLine += 1;
            }
        }
    }


    public void EnableTextBox()
    {
        //Enables the text box object in-game, and locally sets our activation bool to start running our update loop. 
        goTextBox.SetActive(true);
        bActive = true;
    }

    public void DisableTextBox()
    {
        //Disables the text box game object in-game, and locally sets our acitvation bool to false to skip our update loop.
        goTextBox.SetActive(false);
        bActive = false;

        //If we have a string assigned to our NewLevel variable, attempt to load that level when the last dialog line is dismissed by the player.
        //If no variable is assigned, skip this step.
        if(sNewLevel != "")
        {
            print("Dialog finished, attempting to load level " + sNewLevel);
            Application.LoadLevel(sNewLevel);
        }
    }


    //This function should be called whenever we want to load in a new set of dialog. Will completely overwrite any existing dialog.
    //Also called once on game start as validation to make sure we didn't feed junk variables into the manager. 
    public void LoadTextData(TextAsset taNewFile, int iNewStartingLine, int iNewEndingLine)
    {

        //Create a temporary list to store our parsed strings until we move them into our permanent variable. 
        string[] sNewStrings;

        //Check to make sure we actually have a text file to load. 
        if (taNewFile == null)
        {
            print("[Error] No text file provided, aborting text load function.");
            DisableTextBox();
            return;
        }

        //Split the text file out into individual strings, deliniated by newline characters. 
        sNewStrings = taNewFile.text.Split('\n');
        if (sNewStrings.Length <= 0)
        {
            print("[Error] Loaded text file is empty, aborting text load function.");
            DisableTextBox();
            return;
        }

        //Now that we've validated our new new text strings, move them from function stoage to public storage. 
        sTextLines = sNewStrings;

        //Checks our new starting line to ensure it's valid, then sets the variable to the new starting line.
        if (iNewStartingLine < 1)
        {
            print("[Warning] Given starting line is non-positive, setting starting line to 1 instead...");
            iStartingLine = 1;
        }
        else
        {
            print("Setting starting line to " + iNewStartingLine + ".");
            iStartingLine = iNewStartingLine;
        }
        //Sets the current line to the starting line, since we just loaded new text.
            iCurrentLine = iStartingLine;
 

        //Checks our new ending line to ensure it's valid, then sets the variable to the new starting line.
        if (iNewEndingLine > sNewStrings.Length)
        {
            print("[Warning] Given ending line is greater than length of our text list, setting ending line to max length instead...");
            iEndingLine = sNewStrings.Length;
        }
        else
        {
            print("Setting ending line to " + iNewEndingLine + ".");
            iEndingLine = iNewEndingLine;
        }



        print("Text Load completed successfully.");
    }

}

