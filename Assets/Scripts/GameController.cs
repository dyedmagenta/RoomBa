using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes Game Board
/// Communication between UI and state of the game
/// Generates Level (Przemek), 
/// Instantiates RoomBa command panel (Krzysiek)
/// Main Game Loop
/// </summary>
public class GameController : MonoBehaviour
{
    //Example Prototype level
    //Level has to contain - RoomBa, Obstacles, Starting Point
    public GameObject PrototypeLevel;

    //Level that should be generated
    private GameObject _generatedLevel;

    //Prototype CommandPanel
    public GameObject CommandPanel;

    public static GameController Instance { get; private set; }
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

    /// <summary>
    /// Initializes GameBoard
    /// </summary>
    public void StartGame()
    {
        Instantiate(GameBoard);
    }
    
}
