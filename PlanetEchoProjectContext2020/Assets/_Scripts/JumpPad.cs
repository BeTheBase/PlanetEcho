using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float collAnglePrecision = 15f;
    [SerializeField] private float launchStrength = 10f;

    private void Boost(Rigidbody rb)
    {
        rb.velocity = new Vector3(rb.velocity.x, launchStrength, rb.velocity.z);
    }

    #region CollisionHandling

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.HasComponent<Rigidbody>())
        {
            List<ContactPoint> contactPoints = new List<ContactPoint>();
            collision.GetContacts(contactPoints);
            if (CheckOnCollisionHits(contactPoints))
            {
                Boost(collision.gameObject.GetComponent<Rigidbody>());
            }
        }
    }

    private bool CheckOnCollisionHits(List<ContactPoint> contactPoints)
    {
        for (int i = 0; i < contactPoints.Count; i++)
        {
            if (contactPoints[i].otherCollider == null) break;

            Vector3 dir = contactPoints[i].normal;

            //Up
            if (Vector3.Angle(dir, Vector3.down) <= collAnglePrecision && Vector3.Angle(dir, Vector3.up) >= -collAnglePrecision)
            {
                return true;
            }

        }

        return false;
    }
    #endregion
}
