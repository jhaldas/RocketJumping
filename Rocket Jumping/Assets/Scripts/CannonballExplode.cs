using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballExplode : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        Destroy(this.gameObject);
    }
}
