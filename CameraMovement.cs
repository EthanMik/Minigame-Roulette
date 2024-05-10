using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Transform player;

    public void MoveCamera(Vector3 offset)
    {
        transform.position = target.position + offset;
    }

    private void Update()
    {
        int playerXPosition = (int)player.position.x;

        if ((playerXPosition) + 10 < transform.position.x)
        {
            transform.position = new Vector3(target.position.x - 20, target.position.y, target.position.z);
        }
        if ((playerXPosition) - 10 > transform.position.x)
        {
            transform.position = new Vector3(target.position.x + 20, target.position.y, target.position.z);
        }
    }
}

