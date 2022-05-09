using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] Transform player;
    [SerializeField] float speed;


    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, speed);
    }
}
