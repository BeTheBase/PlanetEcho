using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Bas;

namespace Ruben 
{
    public class InteractableObject : MonoBehaviour, Iinteractable
    {
        [SerializeField] private UnityEvent OnInteract;

        public void Interact()
        {
            OnInteract?.Invoke();
        }
    }
}
