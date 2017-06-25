using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct SensorReading
{
    public string SensorName;
    public float Distance;

    public SensorReading(string name, float distance)
    {
        SensorName = name;
        Distance = distance;
    }
}

public class Sensor : MonoBehaviour
{
    public SensorReading SensorData
    {
        get { return _sensorData; }
    }
    private SensorReading _sensorData;

    /// <summary>
    /// Checks for obstacles in every fixed frame 
    /// Draws raycast in editor
    /// </summary>
    void FixedUpdate ()
    {
        
        RaycastHit ray;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out ray))
        {
            Debug.DrawLine(transform.position, ray.point, Color.red);
            _sensorData = new SensorReading(this.name, ray.distance); 
        }
        else
        {
            _sensorData = new SensorReading(this.name, -1);
        }
    }


}
