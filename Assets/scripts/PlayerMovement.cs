using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed;
    private bool canMove = true;

    public bool IsMoving { get; set; }
    public bool CanMove { get => canMove; set => canMove = value; }

    private void Start()
    {
        Ragdoll(false);
    }

    private void Update()
    {
        GetPlayerMovement();
    }


    private void FixedUpdate()
    {
        PlayerMover();

    }

    private void GetPlayerMovement()
    {
        if (canMove)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                IsMoving = true;
            }

            else if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
            {
                IsMoving = false;
            }

        }

        else if (!CanMove)
        {
            IsMoving = false;
        }

    }
    private void PlayerMover()
    {
        if (IsMoving)
        {
            transform.Translate(new Vector3(0f, 0f, _movementSpeed * Time.deltaTime));
        }
        
        GetComponent<Animator>().SetBool("isRunning", IsMoving);
    }


    public void Ragdoll(bool active)
    {
        GetComponent<Animator>().enabled = !active;

        Rigidbody[] rigidbodies = transform.GetChild(0).GetComponentsInChildren<Rigidbody>();
        Collider[] colliders = transform.GetChild(0).GetComponentsInChildren<Collider>();

        foreach (Rigidbody rig in rigidbodies)
            rig.isKinematic = !active;

        foreach (Collider col in colliders)
            col.enabled = active;

        GetComponent<Collider>().enabled = !active;

    }
}
