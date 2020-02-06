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
            if(other.gameObject.HasComponent<NpcTrigger>())
            {
                var trigger = other.gameObject.GetComponent<NpcTrigger>();
                trigger.TriggerDialogue();
                MonoBehaviour playerMovment = this.gameObject.GetComponent<MovementController>();
                playerMovment.enabled = false;
                StartCoroutine(ActivateBehaviour(playerMovment, trigger.PlayerFreezeTime));
            }
        }

        private IEnumerator ActivateBehaviour(MonoBehaviour behaviour, float time)
        {
            yield return new WaitForSeconds(time);
            behaviour.enabled = true;
        }
    }
}
