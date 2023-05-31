using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotate;
    void Update()
    {
        if (GameManager.GameManagerInstance.gameState)
        {
            transform.Rotate(rotate, Space.World);
        }
    }
}
