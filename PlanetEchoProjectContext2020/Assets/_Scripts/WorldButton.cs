using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Bas
{
    public class WorldButton : MonoBehaviour, Iinteractable
    {
        public float HoverSize = 0.75f;
        public UnityEvent OnClick = new UnityEvent();
        private GameObject definedButton;

        void OnMouseEnter()
        {
            //If your mouse hovers over the GameObject with the script attached, output this message
            Debug.Log("Mouse is over GameObject.");
            transform.localScale += Vector3.one * HoverSize;
        }

        void OnMouseExit()
        {
            //The mouse is no longer hovering over the GameObject so output this message each frame
            Debug.Log("Mouse is no longer on GameObject.");
            transform.localScale -= Vector3.one * HoverSize;
        }

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
