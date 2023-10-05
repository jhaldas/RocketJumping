using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketJump : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    [SerializeField] private float m_Thrust = 100f;
    [SerializeField] private float distanceFromExplosionScalar;  // Scales thrust based on how far away you were from explosion (closer = more thrust)
    [SerializeField]
    float maxVelocity = 5f;

    float explosionOffset = 1.5f;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(m_Rigidbody.velocity.magnitude > maxVelocity)
        {
            m_Rigidbody.velocity = Vector3.ClampMagnitude(m_Rigidbody.velocity, maxVelocity);
        }
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
                Vector3 blastAngle = new Vector3(transform.position.x - other.transform.position.x, transform.position.y + explosionOffset - other.transform.position.y, 0);
                m_Rigidbody.AddForce(blastAngle.normalized * m_Thrust / (blastAngle.magnitude * distanceFromExplosionScalar));
                script.hasInteractedWithPlayer = true;
            }
        }
    }
}
