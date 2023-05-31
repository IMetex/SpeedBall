using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTarget;
    [SerializeField] private Transform newCameraPos;
    [SerializeField] private Vector3 offset;

    void LateUpdate()
    {
        if (playerTarget != null)
        {
            transform.position = playerTarget.position + offset;

        }
        if (GameManager.GameManagerInstance.gameOver == true) 
        {
            transform.position = Vector3.Lerp(transform.position, newCameraPos.transform.position, 0.2f);
        }

    }
}
