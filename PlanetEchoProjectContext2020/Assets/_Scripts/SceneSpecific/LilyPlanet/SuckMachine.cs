using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ruben
{
    public class SuckMachine : MonoBehaviour
    {
        public LayerMask layerMask;
        public float suckStrength;
        public float distStrength;
        public Transform shootingPoint;

        [SerializeField] private string animShootingBool = "isShooting";

        private InputManager input;
        private Animator animator;

        private void Start()
        {
            input = InputManager.Instance;
        }

        private void Update()
        {
            shootingPoint.gameObject.SetActive(input.leftMouseButtonPressed);
            animator.SetBool(animShootingBool, input.leftMouseButtonPressed);
            if (input.leftMouseButtonPressed)
            {
                Sucking();
            }
        }

        private void Sucking()
        {
            RaycastHit[] results = Physics.BoxCastAll(shootingPoint.position + shootingPoint.forward * 3, new Vector3(1, 1, 3), shootingPoint.forward, shootingPoint.rotation, 10f, layerMask, QueryTriggerInteraction.Collide);

            for (int i = 0; i < results.Length; i++)
            {
                if (results[i].transform.gameObject.HasComponent<Isuckable>())
                {
                    results[i].transform.GetComponent<Isuckable>().GetSuckedTo(shootingPoint.position, 
                        suckStrength / ((Vector3.Distance(shootingPoint.position, results[i].transform.position) * distStrength)));
                }
            }

        }
    }
}
