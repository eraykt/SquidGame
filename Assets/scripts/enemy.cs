using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] PlayerMovement _player;
    bool rotate = true;

    RaycastHit hit;

    float timer;

    private void Update()
    {
        if (_player.CanMove)
        {
            Rotator();
            OnRotationFinished();
        }
    }

    private void OnRotationFinished()
    {
        if (transform.localRotation.y < 0f)
        {
            rotate = false;
            if (Physics.Raycast(transform.position, -transform.forward, out hit))
            {
                if (_player.IsMoving)
                {
                    _player.CanMove = false;
                    _player.Ragdoll(true);
                }
            }
        }
    }

    private void Rotator()
    {
        if (rotate)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }

        else if (!rotate)
        {
            timer += Time.deltaTime;

            if (timer > 2f)
            {
                timer = 0f;
                speed = Random.Range(100f, 200f);
                RotateAgain();
            }
        }
    }

    private void RotateAgain()
    {
        transform.localRotation = new Quaternion(transform.localRotation.x, 0f, transform.localRotation.z, 1f);
        rotate = true;
    }

}
