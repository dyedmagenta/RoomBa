using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    private GameObject _mainMenu;
    private GameObject _optionsMenu;
    public static MenuController Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Use this for initialization
    void Start()
    {
        // Sets references to Menus
        foreach (Transform child in transform)
        {
            if (child.tag == "Main Menu")
            {
                _mainMenu = child.gameObject;
            }
            if (child.tag == "Options Menu")
            {
                _optionsMenu = child.gameObject;
            }
        }	
	}

    public void SwitchToMainMenu()
    {
        DisbleAllMenu();
        _mainMenu.SetActive(true);
    }

    public void SwitchToOptionsMenu()
    {
        DisbleAllMenu();
        _optionsMenu.SetActive(true);
    }

    private void DisbleAllMenu()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void QuitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying == true)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        Application.Quit();
    }
}
