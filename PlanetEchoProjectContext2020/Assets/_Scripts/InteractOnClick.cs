using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bas
{
    public class InteractOnClick : MonoBehaviour
    {
        void Update()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject.HasComponent<Iinteractable>())
                {
                    Hit.collider.gameObject.GetComponent<Iinteractable>().Interact();
                }
            }
        }
    }
}
