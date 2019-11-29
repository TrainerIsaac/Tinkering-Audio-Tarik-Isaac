using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNav : MonoBehaviour
{
    // Canvas name - changeable in editor.
    public GameObject MainMenu;
    public GameObject SettingsMenu;

    // Show settings menu and hide main.
    public void ToSettings()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    // Show main menu and hide settings.
    public void ToMain()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }

    // Quit the application.
    public void OnQuit()
    {
        Application.Quit();
    }

}
