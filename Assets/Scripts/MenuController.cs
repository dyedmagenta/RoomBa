using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Manages Menu UI
/// </summary>
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

    /// <summary>
    /// Disables Main Menu then Starts Game through Game Controller
    /// </summary>
    public void StartGame()
    {
        DisbleAllMenu();
        GameController.Instance.StartGame();
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
