using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWeapon : MonoBehaviour
{
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private Transform cannonballSpawnPoint;
    [SerializeField] private float speed = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, cannonballSpawnPoint.position, transform.rotation) as Rigidbody;
 
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
        }
    }

    
}
