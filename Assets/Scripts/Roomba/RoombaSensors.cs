using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Instantiates and keeps list of Sensors used by Roomba
/// </summary>
public class RoombaSensors : MonoBehaviour
{
    //TODO: Change sensors naming, use enum maybe

    /// <summary>
    /// Sensor Prefab
    /// </summary>
    public GameObject Sensor;
    /// <summary>
    /// List of sensor components
    /// </summary>
    private List<Sensor> _sensors;
    /// <summary>
    /// List of readings from every sensor
    /// </summary>
    public List<SensorReading> SensorReadings
    {
        get
        {
            List<SensorReading> readings = new List<SensorReading>();
            foreach (var sensor in _sensors)
            {
                readings.Add(sensor.SensorData);
            }
            return readings;
        }
    }
    void Awake()
    {
        _sensors = new List<Sensor>();
        InstatiateSensors();
    }

    /// <summary>
    /// Instantiating Needed sensors
    /// Eight should be enough
    /// </summary>
    private void InstatiateSensors()
    {
        CreateSensor("Front Sensor", new Vector3(0, 0, 0.5f), Quaternion.Euler(0, 0, 0));
        CreateSensor("Front Left Sensor", new Vector3(-0.35f, 0, 0.35f), Quaternion.Euler(0, -45, 0));
        CreateSensor("Left Sensor", new Vector3(-0.5f, 0, 0f), Quaternion.Euler(0, -90, 0));
        CreateSensor("Back Left Sensor", new Vector3(-0.35f, 0, -0.35f), Quaternion.Euler(0, 225, 0));
        CreateSensor("Back Sensor", new Vector3(0f, 0, -0.5f), Quaternion.Euler(0, 180, 0));
        CreateSensor("Back Right Sensor", new Vector3(0.35f, 0, -0.35f), Quaternion.Euler(0, -225, 0));
        CreateSensor("Right Sensor", new Vector3(0.5f, 0, 0f), Quaternion.Euler(0, 90, 0));
        CreateSensor("Front Right Sensor", new Vector3(0.35f, 0, 0.35f), Quaternion.Euler(0, 45, 0));
    }
    /// <summary>
    /// Create Single Sensor
    /// </summary>
    /// <param name="sensorName">Name of the sensor</param>
    /// <param name="position">Local position of the sensor</param>
    /// <param name="rotation">Sensors rotation</param>
    private void CreateSensor(string sensorName, Vector3 position, Quaternion rotation)
    {
        GameObject sensor = Instantiate(Sensor, transform, false);
        sensor.transform.localPosition = position;
        sensor.transform.localRotation = rotation;
        sensor.name = sensorName;
        _sensors.Add(sensor.GetComponent<Sensor>());
    }
    
}
