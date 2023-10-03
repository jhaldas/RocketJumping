using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketJump : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    [SerializeField] private float m_Thrust = 100f;
    [SerializeField] private float distanceFromExplosionScalar;  // Scales thrust based on how far away you were from explosion (closer = more thrust)

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // When collision between a player and explosion happens, player will be given a force in the direction opposite to explosion center.
    // Explosion force scales on how close the player was to the center of explosion.
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Explosion")
        {
            Explosion script = other.GetComponent<Explosion>();
            if(script.hasInteractedWithPlayer == false)
            {
                Vector3 blastAngle = new Vector3(transform.position.x - other.transform.position.x, transform.position.y - other.transform.position.y, 0);
                Debug.Log(blastAngle.magnitude);
                m_Rigidbody.AddForce(blastAngle.normalized * m_Thrust / (blastAngle.magnitude * distanceFromExplosionScalar));
                script.hasInteractedWithPlayer = true;
            }

        }
    }
}
