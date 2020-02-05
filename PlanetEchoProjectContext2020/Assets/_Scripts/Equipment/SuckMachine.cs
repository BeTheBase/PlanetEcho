using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckMachine : MonoBehaviour
{
    private InputManager input;

    private void Start()
    {
        input = InputManager.Instance;
    }

    private void Update()
    {
        if (input.leftMouseButtonPressed)
        {
            Sucking();
        }
    }

    private void Sucking()
    {

    }
}
