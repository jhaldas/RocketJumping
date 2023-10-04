using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateWeapon : MonoBehaviour
{

	[SerializeField] 
	private Rigidbody projectile;

    [SerializeField] 
	private Transform cannonballSpawnPoint;

    [SerializeField] 
	private float speed = 20f;

	[SerializeField]
	private float mouseZConstant = 5.23f;
    void Update()
    {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = mouseZConstant;

		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float temp = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, temp));

		if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, cannonballSpawnPoint.position, transform.rotation) as Rigidbody;
 
            instantiatedProjectile.velocity = transform.TransformDirection(transform.rotation * Vector3.right * speed);
        }
    }
}
