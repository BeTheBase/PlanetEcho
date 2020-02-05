using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ruben
{
    public class SuckMachine : MonoBehaviour
    {
        public float suckStrength;
        public Transform shootingPoint;

        private InputManager input;

        private void Start()
        {
            input = InputManager.Instance;
        }

        private void Update()
        {
            shootingPoint.gameObject.SetActive(input.leftMouseButtonPressed);
            if (input.leftMouseButtonPressed)
            {
                Sucking();
            }
        }

        private void Sucking()
        {
            RaycastHit[] results = Physics.BoxCastAll(shootingPoint.position + shootingPoint.forward * 3, new Vector3(1, 1, 3), shootingPoint.forward, shootingPoint.rotation);

            for (int i = 0; i < results.Length; i++)
            {
                if (results[i].transform.gameObject.HasComponent<Isuckable>())
                {
                    results[i].transform.GetComponent<Isuckable>().GetSuckedTo(shootingPoint.position, 
                        suckStrength / ((Vector3.Distance(shootingPoint.position, results[i].transform.position) * 2) + 1));
                }
            }

        }
    }
}
