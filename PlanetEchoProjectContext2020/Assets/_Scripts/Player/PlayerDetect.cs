using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ruben;

namespace Bas
{
    public class PlayerDetect : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.HasComponent<Iinteractable>())
            {
                var trigger = other.gameObject.GetComponent<Iinteractable>();
                trigger.Interact();
            }
        }
    }
}
