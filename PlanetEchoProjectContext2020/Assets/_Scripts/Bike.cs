using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour
{
    public List<Transform> Planets;

    public float Speed = 10f;

    public Transform startPosition;

    private float timer = 0;
    private int planetIndex = 0;

    private void Start()
    {
        startPosition = this.transform;
        EventManager<int>.AddHandler(EVENT.loadGame, GetPlanetIndex);
    }

    public void GetPlanetIndex(int index)
    {
        planetIndex = index-1;
        MoveBike();
    }

    private void MoveBike()
    {
        transform.LerpTransform(this, Planets[planetIndex].position, Speed);
    }
}
