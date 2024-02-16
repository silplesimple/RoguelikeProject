using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CameraManager.instance.MoveCamera(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        }
    }
}
