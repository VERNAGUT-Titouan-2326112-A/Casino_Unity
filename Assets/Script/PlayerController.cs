using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 velocity;
    private bool isGrounded = true;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ✅ On vérifie si le joueur est au sol
        Vector3 groundCheckPos = transform.position + Vector3.up * 0.2f;

        // ✅ Si le joueur touche le sol et tombe, on stoppe la vitesse vers le bas
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // ✅ Déplacement horizontal
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * speed * Time.deltaTime);

        // ✅ Gravité
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // ✅ Animation : grounded et MoveSpeed
        animator.SetBool("Grounded", isGrounded);
        animator.SetFloat("MoveSpeed", move.magnitude);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // ✅ Visualisation de la sphère de détection au sol
    void OnDrawGizmosSelected()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Vector3 groundCheckPos = transform.position + Vector3.up * 0.5f;
        Gizmos.DrawWireSphere(groundCheckPos, groundDistance);
    }
}
