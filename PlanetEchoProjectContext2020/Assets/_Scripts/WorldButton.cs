using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Bas
{
    public class WorldButton : MonoBehaviour, Iinteractable
    {
        public UnityEvent OnClick = new UnityEvent();
        private GameObject definedButton;

        void Start()
        {
            definedButton = this.gameObject;
        }

        public void Interact()
        {
            Debug.Log("Interacting with: " + this.gameObject.name);
            OnClick.Invoke();
        }
    }
}
