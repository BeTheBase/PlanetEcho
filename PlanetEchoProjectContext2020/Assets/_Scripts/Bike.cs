using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour
{
    public Transform EndPosition;

    public float Speed = 10f;

    public Transform startPosition;
    public Vector3 EndVector;

    private float timer = 0;

    private void Start()
    {
        startPosition = this.transform;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        transform.position = Vector3.Lerp(startPosition.position, EndPosition.position, Mathf.PingPong(timer * Speed, 1.0f));
    }
}
