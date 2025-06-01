using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [Header("Components")]
    public Planet red;
    public Planet blue;

    public Planet chosenPlanet;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        
    }

    public void RotateToAngle(float angleRad)
    {
        float angleDeg = angleRad * Mathf.Rad2Deg;
        blue.transform.RotateAround(red.transform.position, Vector3.forward, -angleDeg);
    }

    public void Rewind()
    {

    }

    public void Revive()
    {

    }

    public void SwitchChosen()
    {

    }

    public void MovePlanet(Vector2 position, Floor floor)
    {

    }

    private Floor GetFloorAtPosition(Vector2 position)
    {
        return gameObject.AddComponent<Floor>();
    }

    private void MoveToNextFloor(Floor floor, float exitAngle)
    {

    }

    public void Die()
    {

    }
}
