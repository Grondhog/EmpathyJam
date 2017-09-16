using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{

    //These colors will be used to change how the button looks when moused over/clicked on.
    //Defined on prefab but can also be changed locally if necessary. 
    public Color cBaseColor;
    public Color cOverColor;
    public Color cClickColor;

    //Variable to store a reference to our button's Image component.
    private Image iImage;

    // Use this for initialization
    void Start()
    {

        //Gets a reference to our button's Image component.
        iImage = GetComponent<Image>();
        if (iImage != null)
        {
            //Changes our Images' color to the defined Base Color.
            iImage.color = cBaseColor;
        }
        else
        {
            //If we have no Image component, print an error to console.
            print("[Error]! Button object has no image component!");
        }
    }

    //This is what we do when the player mouses over any button.
    //This gets called from the Event Triggers component on the button object itself. 
    public void MouseOver()
    {
        //Highlight the button when the player mouses over it.
        iImage.color = cOverColor;
    }

    //This is what we do when the player mouses off of any button.
    //This gets called from the Event Triggers component on the button object itself. 
    public void MouseExit()
    {
        //Return the button to it's base color when the player is no longer mousing over it.
        iImage.color = cBaseColor;
    }

    //This is what we do when the player pressed the mouse button down on any button.
    //This gets called from the Event Triggers component on the button object itself. 
    public void MouseDown()
    {
        //Highlight the button when the player presses down on it. 
        //If the player releases the mouse click we will run MouseClicked() immediately after this.
        //The player can 'abort' their mouse click by moving the mouse off of the button before releasing the mouse.
        iImage.color = cClickColor;
    }

    //This is what we do when the player clicks and releases the mouse button on any button. 
    //This gets called from the Event Triggers component on the button object itself. 
    public void MouseClicked()
    {
        //We don't actually do anything on this function, because each button should probably have it's own unique functionality when clicked(see below).
        //However, this is a useful placeholder function for testing buttons before hooking up their functionality.
        print("Button Pressed!");
    }


    ////////////////////////////////
    // Unique Button Functionality//
    ////////////////////////////////

    //This is the function we run when the player clicks on the Play button on the main menu.
    public void PlayButtonClicked()
    {
        //Loads the first scene for the game, where the player comes out to their parents over dinner.
        //NOTE: In order to load a scene from script like this, it must first be added to the project settings in File -> Build Settings (Ctrl+Shift+B).
        Application.LoadLevel("DinnerScene");
    }

    //This is the function we run when the player clicks on the Quit button on the main menu.
    public void ExitButtonClicked()
    {
        //Quits the game. Won't actually do anything if running the game in-editor. 
        Application.Quit();
    }
}
