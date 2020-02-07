using System.Collections;
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
                    AudioManager.Instance.Play("Plop", transform.position);
                    PlanetLily.Instance.AddDestroyedWooshie();
                    Destroy(gameObject);
                }
            }
        }

        public void GetSuckedTo(Vector3 pos, float suckStrength)
        {
            transform.position += transform.position.GetDirectionTo(pos) * suckStrength * Time.deltaTime;
        }
    }
}
