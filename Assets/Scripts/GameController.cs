using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes Game Board
/// Communication between UI and state of the game
/// Generates Level (Przemek), 
/// Instantiates command panel (Krzysiek)
/// 
/// Manages Game Loop
/// </summary>
public class GameController : MonoBehaviour
{
    //Example Prototype level
    public GameObject PrototypeLevel;

    //Flag for prototyping true for generated level, false for level prototype
    public bool IsLevelGenerated;
    
    //Level that should be generated
    private GameObject _generatedLevel;

    private GameObject _level;
    private GameObject _roomba;
    private GameObject _commandPanel;
    private Transform _startPoint;

    //Prototype CommandPanel
    public GameObject CommandPanel;

    public GameObject Roomba;

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
        GenerateLevel();
        CreateRoomBa();
        CreateCommandPanel();

        Debug.Log("Game Started!");
    }

    /// <summary>
    /// Generates Level and sets up references like starting point in the level
    /// </summary>
    private void GenerateLevel()
    {
        if (IsLevelGenerated)
        {
            // Generate Level
            _level = Instantiate(_generatedLevel);
        }
        else
        {
            // Use Prototype
            _level = Instantiate(PrototypeLevel);
        }

        foreach (Transform child in _level.transform)
        {
            if (child.tag == "Start Point")
            {
                _startPoint = child;
            }
        }
    }

    /// <summary>
    /// Instantiates and sets up references to CommandPanel
    /// </summary>
    private void CreateCommandPanel()
    {
        if (CommandPanel == null) return;
        
        _commandPanel = Instantiate(CommandPanel);
        var commandPanelController = _commandPanel.GetComponent<CommandPanelController>();
        commandPanelController.RoombaEngines = _roomba.GetComponent<RoombaEngines>();
        commandPanelController.RoombaSensors = _roomba.GetComponent<RoombaSensors>();
    }

    private void CreateRoomBa()
    {
       _roomba = Instantiate(Roomba, _startPoint.position, _startPoint.rotation);
    }
}
