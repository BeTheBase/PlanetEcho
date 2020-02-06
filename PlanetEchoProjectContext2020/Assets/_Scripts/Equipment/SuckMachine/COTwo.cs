﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ruben
{
    public class COTwo : MonoBehaviour, Isuckable
    {
        private void OnTriggerEnter(Collider other)
        {
            if (InputManager.Instance.leftMouseButtonPressed)
            {
                if (other.gameObject.HasComponent<SuckMachine>())
                {
                    Destroy(gameObject);
                    other.gameObject.GetComponent<SuckMachine>().deletedNum += 1;
                }
            }
        }

        public void GetSuckedTo(Vector3 pos, float suckStrength)
        {
            transform.position += transform.position.GetDirectionTo(pos) * suckStrength * Time.deltaTime;
        }
    }
}
