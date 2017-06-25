using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPanelController : MonoBehaviour {

	public RoombaEngines RoombaEngines { get; set; }

    public void Left()
    {
        RoombaEngines.RoombaRotationState = RoombaEngines.RoombaEngineStates.Backward;
    }
    public void Right()
    {
        RoombaEngines.RoombaRotationState = RoombaEngines.RoombaEngineStates.Forward;
    }
    public void Forward()
    {
        RoombaEngines.RoombaMovementState = RoombaEngines.RoombaEngineStates.Forward;
    }
    public void Backward()
    {
        RoombaEngines.RoombaMovementState = RoombaEngines.RoombaEngineStates.Backward;
    }
    public void Stop()
    {
        RoombaEngines.RoombaMovementState = RoombaEngines.RoombaEngineStates.Stop;
        RoombaEngines.RoombaRotationState = RoombaEngines.RoombaEngineStates.Stop;
    }
}
