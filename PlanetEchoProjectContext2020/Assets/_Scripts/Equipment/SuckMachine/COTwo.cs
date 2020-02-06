using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ruben
{
    public class COTwo : MonoBehaviour, Isuckable
    {
        public void GetSuckedTo(Vector3 pos, float suckStrength)
        {
            transform.position += transform.position.GetDirectionTo(pos) * suckStrength * Time.deltaTime;
        }
    }
}
