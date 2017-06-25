using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPanelController : MonoBehaviour
{
    /// <summary>
    /// References to Sensor Readings Text
    /// </summary>
    public SensorTexts SensorTexts;
    /// <summary>
    /// References to images that show where roomba is moving
    /// </summary>
    public DirectionArrows DirectionArrows;
	public RoombaEngines RoombaEngines { get; set; }
    public RoombaSensors RoombaSensors { get; set; }
    public void Left()
    {
        RoombaEngines.RoombaRotationState = RoombaEngines.RoombaEngineStates.Backward;

        DirectionArrows.Right.SetActive(false);
        DirectionArrows.Left.SetActive(true);
    }
    public void Right()
    {
        RoombaEngines.RoombaRotationState = RoombaEngines.RoombaEngineStates.Forward;

        DirectionArrows.Right.SetActive(true);
        DirectionArrows.Left.SetActive(false);
    }
    public void Forward()
    {
        RoombaEngines.RoombaMovementState = RoombaEngines.RoombaEngineStates.Forward;

        DirectionArrows.Front.SetActive(true);
        DirectionArrows.Back.SetActive(false);
    }
    public void Backward()
    {
        RoombaEngines.RoombaMovementState = RoombaEngines.RoombaEngineStates.Backward;

        DirectionArrows.Front.SetActive(false);
        DirectionArrows.Back.SetActive(true);
    }
    public void Stop()
    {
        RoombaEngines.RoombaMovementState = RoombaEngines.RoombaEngineStates.Stop;
        RoombaEngines.RoombaRotationState = RoombaEngines.RoombaEngineStates.Stop;

        DirectionArrows.HideDirectionArrows();
    }
    public void Scan()
    {
        var currentReadings = RoombaSensors.SensorReadings;
        foreach (var reading in currentReadings)
        {
            switch (reading.SensorName)
            {
                case "Front Sensor":
                    SensorTexts.Front.text = reading.Distance.ToString("F");
                    break;
                case "Front Left Sensor":
                    SensorTexts.FrontLeft.text = reading.Distance.ToString("F");
                    break;
                case "Left Sensor":
                    SensorTexts.Left.text = reading.Distance.ToString("F");
                    break;
                case "Back Left Sensor":
                    SensorTexts.BackLeft.text = reading.Distance.ToString("F");
                    break;
                case "Back Sensor":
                    SensorTexts.Back.text = reading.Distance.ToString("F");
                    break;
                case "Back Right Sensor":
                    SensorTexts.BackLeft.text = reading.Distance.ToString("F");
                    break;
                case "Right Sensor":
                    SensorTexts.Right.text = reading.Distance.ToString("F");
                    break;
                case "Front Right Sensor":
                    SensorTexts.FrontRight.text = reading.Distance.ToString("F");
                    break;
            }
        }
    }
}

/// <summary>
/// Packs UIText for sensor readings
/// </summary>
[System.Serializable]
public class SensorTexts
{
    public Text Front;
    public Text FrontRight;
    public Text Right;
    public Text BackRight;
    public Text Back;
    public Text BackLeft;
    public Text Left;
    public Text FrontLeft;
}
/// <summary>
/// Packs direction arrows that show where roomba is moving
/// </summary>
[System.Serializable]
public class DirectionArrows
{
    public GameObject Front;
    public GameObject Right;
    public GameObject Back;
    public GameObject Left;

    public void HideDirectionArrows()
    {
        Front.SetActive(false);
        Right.SetActive(false);
        Back.SetActive(false);
        Left.SetActive(false);
    }
}