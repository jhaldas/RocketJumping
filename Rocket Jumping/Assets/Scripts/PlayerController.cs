using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool facingRight;
    [SerializeField] private float rayFromGroundDistance = 2f;
    [SerializeField] private Transform backHandGrip;
    [SerializeField] private Transform frontHandGrip;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform weapon;

    void Start()
    {
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Airborne", !IsGrounded());
        HandleFacingRight();
    }

    // Checks if player is currently touching ground
    bool IsGrounded() {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        
        bool hit = Physics.Raycast(position, direction, rayFromGroundDistance, groundLayer);
        if (hit) {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Flip player if mouse is behind them.
    void HandleFacingRight()
    {
        Vector3 mousePos = Input.mousePosition;
		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);

		if((mousePos.x > objectPos.x) && !facingRight)
        {
            FlipCharacter();

        }
        else if((mousePos.x < objectPos.x) && facingRight)
        {
            FlipCharacter();
        }
    }

    // Flips the player on the x and z axis when called.
    void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.RotateAround (transform.position, transform.up, 180f);
    }

    // For testing in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(-Vector3.up) * rayFromGroundDistance;
        Gizmos.DrawRay(transform.position, direction);
    }

}


